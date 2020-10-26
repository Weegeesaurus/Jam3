using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    private TimeSpan loopTime;
    private bool running;
    private float elapsedTime;
    public float timePassed;
    public float minPassed;

    private void Awake()    //setting up singleton
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    void Start()    //initialize
    {
        running = false;
        elapsedTime = 0;  //7 am
        StartTime();
    }
    public void StartTime() //begin time
    {
        running = true;
        StartCoroutine(UpdateTime());
    }
    public void StopTime() //stop time
    {
        running = false;
    }
    public IEnumerator UpdateTime()
    {
        while(running)
        {
            elapsedTime += Time.deltaTime;
            loopTime = TimeSpan.FromSeconds(elapsedTime);
            timePassed = loopTime.Seconds;
            minPassed = loopTime.Minutes;

            yield return null;
        }
    }
    public int getSeconds()
    {
        return loopTime.Seconds;
    }
    public int getMinute()
    {
        return loopTime.Minutes;
    }
}
