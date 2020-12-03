using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        //Sets the game in a GAME OVER state if the player is in the room when the lights go out
        if (col.gameObject.tag == "Player")
        {
            WinLoss.gameLose = true;
        }
    }
}
