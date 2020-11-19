using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    public Transform[] positions;
    public WindowCandle candle;
    public bool closed = false;
    private int lighterID;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform obj in positions)
        {
            obj.gameObject.SetActive(false);
        }

        candle.SetLane(this);
        closed = false;
    }
    public Transform NextPos(int position)
    {
        return positions[position];
    }

    public void CloseLane()
    {
        closed = true;
    }
    public void OpenLane()
    {
        closed = false;
        candle.SnuffCandle();
    }
    public bool IsClosed()
    {
        return closed;
    }

    public void ChangeLighterID(int id)
    {
        lighterID = id;
    }

    public int GetLighterID()
    {
        return lighterID;
    }
}
