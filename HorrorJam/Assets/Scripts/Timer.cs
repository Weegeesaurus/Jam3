using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static bool collected;
    public static bool playing;
    public GameObject forester;

    [SerializeField]
    public float time;

    // Update is called once per frame
    void Update()
    {
        //print(collected);
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            forester.SetActive(true);
            Destroy(gameObject);
        }
        
    }
}
