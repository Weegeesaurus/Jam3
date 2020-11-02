using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 This script is responcible for all button functionality outside of gameplay
 */

public class QuitButton : MonoBehaviour
{
    [SerializeField] string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Closes the game when selected
    public void QuitGame()
    {
        Application.Quit();
    }

    //Used to navigate between scenes depending on what you put in the editor
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
