using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    public bool canCollect;

    public static bool collectKey;
    public static bool collectFood;
    public static bool collectNeedle;

    public static bool depositKey;
    public static bool depositFood;
    public static bool depositNeedle;

    // Start is called before the first frame update
    void Start()
    {

        collectKey = false;
        collectFood = false;
        collectNeedle = false;

        depositKey = false;
        depositFood = false;
        depositNeedle = false;
    }

    // Update is called once per frame
    void Update()
    {
        //print("Collect Key: " + collectKey);
        //print("Collect Food: " + collectFood);
        //print("Collect Needle: " + collectNeedle);

        if (collectKey && collectFood && collectNeedle)
        {
            // Uncomment for build
            //Timer.collected = true;
            TimeManager.collected = true;
            print("True!");
        }
    }
}
