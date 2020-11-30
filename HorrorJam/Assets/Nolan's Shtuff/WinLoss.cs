using UnityEngine;

public class WinLoss : MonoBehaviour
{
    public static bool gameWin;
    public static bool gameLose;

    [SerializeField] Camera Game;
    [SerializeField] Camera Title;
    [SerializeField] Camera Win;
    [SerializeField] Camera Loss;

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
            Game.gameObject.SetActive(false);
            Win.gameObject.SetActive(true);
            Loss.gameObject.SetActive(false);
            Title.gameObject.SetActive(false);
        }
        if (gameLose)
        {
            Game.gameObject.SetActive(false);
            Win.gameObject.SetActive(false);
            Loss.gameObject.SetActive(true);
            Title.gameObject.SetActive(false);
        }
    }

    public void GoToMenu()
    {
        Game.gameObject.SetActive(false);
        Win.gameObject.SetActive(false);
        Loss.gameObject.SetActive(false);
        Title.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}