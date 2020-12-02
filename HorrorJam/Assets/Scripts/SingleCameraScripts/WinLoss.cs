using UnityEngine;

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
            CameraMovement.screenToggle = 4;
        }
        if (gameLose)
        {
            CameraMovement.screenToggle = 2;
        }
    }

    public void GoToMenu()
    {
        CameraMovement.screenToggle = 3;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}