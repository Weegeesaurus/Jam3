using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForesterManager : MonoBehaviour
{
    public GameObject forester;
    public Renderer foresterRend;
    public float moveSpeed;
    public LaneManager[] lanes;
    public int laneSize;
    public int activeLane;
    public int currentPos;
    public bool inside;
    public int lighterID;


    // Start is called before the first frame update
    void Start()
    {
        activeLane = Random.Range(0, lanes.Length);
        currentPos = 0;
        Transform newPos = lanes[activeLane].NextPos(currentPos);
        forester.transform.position = newPos.position;
        forester.transform.rotation = newPos.rotation;
        foreach (LaneManager lane in lanes)
        {
            lane.ChangeLighterID(lighterID);
        }

        inside = false;
        Invoke("MoveForester", moveSpeed);
    }

    // Update is called once per frame
    void MoveForester()
    {
        if (currentPos<laneSize-2)
        {
            MoveForward();
            Invoke("MoveForester", moveSpeed);
        }
        else
        {
            if (lanes[activeLane].IsClosed())
            {
                activeLane = Random.Range(0, lanes.Length);
                currentPos = 0;
                Transform newPos = lanes[activeLane].NextPos(currentPos);
                forester.transform.position = newPos.position;
                forester.transform.rotation = newPos.rotation;

                foreach (LaneManager lane in lanes)
                {
                    lane.OpenLane();
                }

                Invoke("MoveForester", moveSpeed);
            }
            else
            {
                inside = true;

                MoveForward();
            }
        }
    }

    void MoveForward()
    {
        currentPos++;
        Transform newPos = lanes[activeLane].NextPos(currentPos);
        forester.transform.position = newPos.position;
        forester.transform.rotation = newPos.rotation;
    }
}
