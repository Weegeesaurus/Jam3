using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireAlarm : MonoBehaviour
{
    private Vector3 targetAngle = new Vector3(-90f, 0f, 0f);
    private Vector3 currentAngle;

    public void triggerAlarm()
    {
        FireAlarmManager.instance.StartAlarm();
    }
}
    
