using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    bool pause;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Camera Game;
    [SerializeField] Camera Controls;
    [SerializeField] Camera MM;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
       if (pause)
       {
            pauseMenu.SetActive(false);
            pause = false;
            Time.timeScale = 1;
            Debug.Log("Game Unpaused");
       }
       else
       {
            pauseMenu.SetActive(true);
            pause = true;
            Time.timeScale = 0;
            Debug.Log("Game Paused");
       }
    }
    public void ControlsScreen()
    {
        pause = false;
        Game.gameObject.SetActive(false);
        Controls.gameObject.SetActive(true);
    }
    public void MMScreen()
    {
        pause = false;
        Game.gameObject.SetActive(false);
        MM.gameObject.SetActive(true);
    }

    public void ReturnToGame()
    {
        Controls.gameObject.SetActive(false);
        Game.gameObject.SetActive(true);
    }

    public void InitiateGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        MM.gameObject.SetActive(false);
        Game.gameObject.SetActive(true);
        Time.timeScale = 1.0f;
    }
}