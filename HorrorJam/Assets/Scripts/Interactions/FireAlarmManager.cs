using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAlarmManager : MonoBehaviour
{
    public static FireAlarmManager instance;
    public bool canActivate = true;
    public float alarmTime = 30;
    public float resetTime = 30;
    public static bool alarmOn = false;

    private void Awake()    //setting up singleton
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Inventory already exists, destroying object!");
            Destroy(this);
        }
    }

    public void StartAlarm()
    {
        if (canActivate)
        {
            canActivate = false;
            alarmOn = true;
            Invoke("alarmOff", alarmTime);
            AudioPlay.PlaySound(1, alarmTime);
            Invoke("ResetAlarm", alarmTime + resetTime);
        }
    }

    private void ResetAlarm()
    {
        canActivate = true;
    }

    private void alarmOff()
    {
        alarmOn = false;
    }
}