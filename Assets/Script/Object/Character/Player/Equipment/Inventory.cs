using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //avalable slots
    [SerializeField]
    private Container_Iteration backpackSlot = null;

    private GameObject backpackSlotUI = null;

    [SerializeField]
    private GameObject containerItemPanel = null;
    [SerializeField]
    private GameObject slotUIElement = null;

    private GameObject inventoryUI = null;

    void Start()
    {
        backpackSlotUI = GameObject.Find("BackpackSlot");
        inventoryUI = GameObject.Find("InventoryUI");
        Equip(backpackSlotUI, backpackSlot);
    }

    public void Equip(GameObject slot, Container_Iteration container)
    {
        GameObject _containerItemPanel = Instantiate(containerItemPanel, transform.position, Quaternion.identity);
        _containerItemPanel.transform.SetParent(inventoryUI.transform);
        _containerItemPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(container.xSize * 100 + 20, container.ySize * 100 + 20);
        _containerItemPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(300, -50);
        int size = container.xSize * container.ySize;
        for (int i = 0; i < size; i++)
        {
            GameObject _slotUIElement = Instantiate(slotUIElement, transform.position, Quaternion.identity);
            _slotUIElement.transform.SetParent(_containerItemPanel.transform);
        }
        slot.GetComponent<Image>().sprite = container.slotSprite;
    }

}
