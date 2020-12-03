using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForesterManager : MonoBehaviour
{
    public GameObject forester;
    public GameObject[] stalkerList;
    public float moveSpeed;
    public LaneManager[] lanes;
    public int laneSize;
    public int activeLane;
    public int currentPos;
    public bool inside;
    public int lighterID;
    public float respawnTime;

    private int stalkerAmount=0;


    // Start is called before the first frame update
    void Start()
    {
        NewLane();

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
                NewLane();

                Invoke("MoveForester", moveSpeed);
            }
            else
            {
                //forester broke in
                inside = true;

                forester.SetActive(false);

                currentPos++;
                Transform newPos = lanes[activeLane].NextPos(currentPos);

                if (stalkerAmount < stalkerList.Length)
                {
                    stalkerList[stalkerAmount].transform.position = newPos.position;
                    stalkerList[stalkerAmount].transform.rotation = newPos.rotation;

                    stalkerList[stalkerAmount].SetActive(true);
                    stalkerAmount++;

                    Invoke("Respawn", respawnTime);
                }
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

    void NewLane()
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
    }

    void Respawn()
    {
        NewLane();
        forester.SetActive(false);
        inside = false;
        Invoke("MoveForester", moveSpeed);
    }
}
