using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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