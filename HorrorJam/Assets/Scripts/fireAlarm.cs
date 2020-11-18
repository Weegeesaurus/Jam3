using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireAlarm : MonoBehaviour
{
    private Vector3 targetAngle = new Vector3(-90f, 0f, 0f);
    private Vector3 currentAngle;

    public bool alarmPulled = false;
    // Start is called before the first frame update
    // Update is called once per frame

    private void Start()
    {

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            alarmPulled = true;
        }
      
    }
    public void triggerAlarm()
    {
        //if (alarmPulled)
        //{
            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime),
                Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
                Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime));
            transform.eulerAngles = currentAngle;

        //}
    }
}
    
