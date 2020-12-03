using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    bool pause;
    
    //The five screens that can appear throughout the game
    [Header("Canvases")]

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject infoScreen;
    [SerializeField] GameObject lossScreen;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject winScreen;

    [SerializeField] GameObject enemies;
    [SerializeField] GameObject foresterTime;
    [SerializeField] GameObject music;

    public int previous;

    //Switch Condition
    public static int screenToggle;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        screenToggle = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //Pauses and unpauses game on Escape button
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            TogglePause();
        }

        //Handles which screens are active in which game state
        switch (screenToggle)
        {
            case 0://Toggles Information Screen
                infoScreen.SetActive(true);
                Time.timeScale = 0f;
                break;

            case 1://Toggles Game Proper
                titleScreen.SetActive(false);
                break;

            case 2://Toggles Loss Screen
                lossScreen.SetActive(true);
                Time.timeScale = 0f;
                enemies.SetActive(false);
                music.SetActive(false);
                break;

            case 3://Toggles Main Menu/Title Screen
                lossScreen.SetActive(false);
                winScreen.SetActive(false);
                titleScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                break;

            case 4://Toggles Win Screen
                winScreen.SetActive(true);
                Time.timeScale = 0f;
                music.SetActive(false);
                break;
        }
    }

    public void TogglePause()
    {
        if (pause)
        {
            //Unpauses the game if the game is currently paused
            pauseMenu.SetActive(false);
            pause = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            //Pauses the game if the game is currently unpaused
            pauseMenu.SetActive(true);
            pause = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }

/*
 * The following functions handle buttons
*/

    //Transitions from Pause Screen to Info Screen
    public void ControlsScreen()
    {
        previous = screenToggle;
        pauseMenu.SetActive(false);
        titleScreen.SetActive(false);
        screenToggle = 0;
    }

    //Reloads the game after it has been completed
    public void InitiateGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        screenToggle = 3;
    }

    //Transitions from Pause Screen to gameplay
    public void ReturnToGame()
    {
        screenToggle = 1;
        TogglePause();
    }

    //Transitions from Info Screen to Pause Screen
    public void ReturnToPause()
    {
        infoScreen.SetActive(false);
        if (previous == 3)
        {
            screenToggle = 3;
        }
        if (previous == 1)
        {
            pauseMenu.SetActive(true);
            screenToggle = 1;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //Transitions from Title Screen to gameplay
    public void StartGame()
    {
        screenToggle = 1;
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        enemies.SetActive(true);
        foresterTime.SetActive(true);
    }
}