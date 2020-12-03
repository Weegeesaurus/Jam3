using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAlarmManager : MonoBehaviour
{
    public static FireAlarmManager instance;
    public bool canActivate=true;

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
			canActivate=false;
			AudioPlay.PlaySound(1,30)
		}
    }

    private void PlaySound()
    {
        canActivate=true;
    }
}
