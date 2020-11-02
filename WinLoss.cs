using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 This script is responcible for transitioning the scene once the game is in gameWin or gameLoss state.
 */

public class WinLoss : MonoBehaviour
{
    public static bool gameWin;
    public static bool gameLose;

    // Start is called before the first frame update
    void Start()
    {
        gameWin = false;
        gameLose = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks the state of global variables each frame to see if the game has been won or lost
        if (gameWin)
        {
            SceneManager.LoadScene("GameComplete");
        }
        if (gameLose)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}