using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCandle : MonoBehaviour
{
    public GameObject unlitCandle;
    public GameObject litCandle;
    private LaneManager lane; 

    void Start()
    {
        litCandle.SetActive(false);
    }

    public void SetLane(LaneManager newLane)
    {
        lane = newLane;
    }
    public void LightCandle()
    {
        if (Inventory.CheckInventory(lane.GetLighterID()))
        {
            lane.CloseLane();
            unlitCandle.SetActive(false);
            litCandle.SetActive(true);
        }

    }
    public void SnuffCandle()
    {
        unlitCandle.SetActive(true);
        litCandle.SetActive(false);
    }
}
