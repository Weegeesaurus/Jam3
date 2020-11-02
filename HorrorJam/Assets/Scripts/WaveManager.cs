using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int timeLimit;
    //public GameObject statue;
    //public Transform[] locations;
    //private bool[] triggers;

    void Start()
    {
        InvokeRepeating("UpdateSec", 1f, 1f);  //1s delay, repeat every 1s
    }

    void UpdateSec()
    {
        if (TimeManager.instance.getMinute() >= timeLimit)
        {
            //end game?
        }
    }

}
