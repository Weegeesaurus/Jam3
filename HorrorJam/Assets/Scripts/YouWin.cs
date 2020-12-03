using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{

    public int win;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            win = 0;
            for (int i = 0; i < 8; i++)
            {
                if (Inventory.CheckInventory(i))
                {
                    win++;
                }
            }
            if (win >= 8)
            {
                WinLoss.gameWin = true;
            }
        }
    }
}