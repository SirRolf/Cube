using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Fetcher : MonoBehaviour
{
    Container_Object _backpackItem;
    private void OnTriggerStay2D(Collider2D col)
    {
        _backpackItem = GetComponentInChildren<Inventory>().backpackItem;
        if (Input.GetAxisRaw("PickUp") != 0)
        {
            var item = col.GetComponent<GroundItem>();
            if (item == true)
            {
                _backpackItem.AddItem(new Item(item.item), 1);
                Destroy(col.gameObject);
                _backpackItem.Save();
            }
        }
    }
    // THIS SHOULD BE DIFFRENT, LOAD WHENEVER SOMTHING HAPPENS BUT I DON'T KNOW WHERE
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _backpackItem = GetComponentInChildren<Inventory>().backpackItem;
            _backpackItem.Load();
        }
    }
}
