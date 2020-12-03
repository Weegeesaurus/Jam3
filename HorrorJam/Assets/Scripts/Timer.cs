using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static bool collected;
    public static bool playing;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        //print(collected);
        if (time > 0 && playing)
        {
            time -= Time.deltaTime;
        }
        else if (playing)
        {
            if (collected)
            {
                print("Win!");
                //WinLoss.gameWin = true;
            }
            else
            {
                print("Lose!");
                //WinLoss.gameLose = true;
            }
        }
    }
}
