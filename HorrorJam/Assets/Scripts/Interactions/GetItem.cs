using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public int itemID;

    public void PickUp()
    {
        Inventory.AddInventory(itemID);
        Destroy(gameObject);
    }
}
