using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Fetcher : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetAxisRaw("PickUp") != 0)
        {
            Container_Object _backpackItem = GetComponentInChildren<Inventory>().backpackItem;

            var item = col.GetComponent<Item>();
            if (item == true)
            {
                _backpackItem.AddItem(item.item, 1);
                Destroy(col.gameObject);
            }
        }
    }
}
