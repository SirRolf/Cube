using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_EquipmentUI : MonoBehaviour
{
    private GameObject inventoryUIParent = null;

    void Start()
    {
        inventoryUIParent = GameObject.Find("InventoryUIParent");
    }

    void Update()
    {
        if (Input.GetAxisRaw("OpenInventory") != 0)
        {
            inventoryUIParent.SetActive(true);
        }
        else
        {
            inventoryUIParent.SetActive(false);
        }
    }
}
