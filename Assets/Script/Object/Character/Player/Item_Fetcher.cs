using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Fetcher : MonoBehaviour
{
    private Container_Storage backpackSlot;
    private void OnTriggerEnter2D(Collider2D col)
    {
        backpackSlot = GetComponentInChildren<Inventory>().backpackSlot;

        var item = col.GetComponent<Item>();
        if (item == true)
        {
            backpackSlot.AddItem(item.item, 1);
            Destroy(col.gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        backpackSlot = GetComponentInChildren<Inventory>().backpackSlot;
        backpackSlot.ItemData.Clear();
    }
}
