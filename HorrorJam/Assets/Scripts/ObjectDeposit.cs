using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDeposit : MonoBehaviour
{
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
        if (depositKey && depositFood && depositNeedle)
        {
            // Uncomment for build
            //WinLoss.gameWin = true;
        }
    }

    private void OnTriggerEnter()
    {
        print("Trigger!");
        if (collectKey)
        {
            collectKey = false;
            depositKey = true;
            print("Deposited Key!");
        }
        if (collectFood)
        {
            collectFood = false;
            depositFood = true;
        }
        if (collectNeedle)
        {
            collectNeedle = false;
            depositNeedle = true;
        }
    }
}
