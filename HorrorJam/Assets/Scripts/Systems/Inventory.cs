using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public bool[] items;


    private void Awake()    //setting up singleton
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Inventory already exists, destroying object!");
            Destroy(this);
        }
    }

    public static bool CheckInventory(int id)
    {
        if (id < Inventory.instance.items.Length)
        {
            return Inventory.instance.items[id];
        }
        else
        {
            Debug.LogError("item ID: " + id + " is out of bounds!");
            return false;
        }
    }
    public static void AddInventory(int id)
    {
        if (id < Inventory.instance.items.Length)
        {
            Inventory.instance.items[id] = true;
        }
        else
        {
            Debug.LogError("item ID: " + id + " is out of bounds!");
        }
    }
}
