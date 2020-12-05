using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutManager : MonoBehaviour
{
    public static BlackoutManager instance;
    public GameObject blackOutObj;
    public GameObject canvas;
    private bool fadeout = false;

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
    void Start()
    {
        FadeIn();
    }

    public void FadeOut()
    {
        if (!fadeout)
        {
            GameObject obj = Instantiate(blackOutObj, canvas.transform);
            obj.GetComponent<Blackout>().FadeOut();
            obj.transform.SetParent(canvas.transform);
            fadeout = true;
        }
    }

    public void FadeIn()
    {
        GameObject obj = Instantiate(blackOutObj, canvas.transform);
        obj.GetComponent<Blackout>().FadeIn();
        obj.transform.SetParent(canvas.transform);
        Debug.Log("spawned in");
    }
}
