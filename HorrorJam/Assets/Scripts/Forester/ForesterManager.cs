using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForesterManager : MonoBehaviour
{
    public GameObject forester;
    public LaneManager[] lanes;
    public int laneSize;
    public int activeLane;
    public int currentPos;
    public bool inside;


    // Start is called before the first frame update
    void Start()
    {
        activeLane = Random.Range(0, lanes.Length);
        currentPos = 0;
        Transform newPos = lanes[activeLane].NextPos(currentPos);
        forester.transform.position = newPos.position;
        forester.transform.rotation = newPos.rotation;
        inside = false;
        Invoke("MoveForester", 10f);
    }

    // Update is called once per frame
    void MoveForester()
    {
        if (currentPos<laneSize-2)
        {
            MoveForward();
            Invoke("MoveForester", 10f);
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

                Invoke("MoveForester", 10f);
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
