using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    /*
    [SerializeField]
    private GameObject slotUIElement = null;
    */
    [SerializeField]
    private GameObject backpackSlot = null;

    /*
    private GameObject inventoryUI = null;
    private GameObject backpackSlotUIElement = null;
    */

    void Start()
    {
        /*
        inventoryUI = GameObject.Find("InventoryUI");
        backpackSlotUIElement = Instantiate(slotUIElement, transform.position, Quaternion.identity);
        backpackSlotUIElement.transform.SetParent(inventoryUI.transform);
        backpackSlotUIElement.GetComponent<RectTransform>().localPosition = new Vector3(-150, 400, 0);
        */
    }
}
