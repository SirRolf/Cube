using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container_Storage : MonoBehaviour
{
    [SerializeField]
    private int xSize = 0;
    [SerializeField]
    private int ySize = 0;
    private int size = 0;

    [SerializeField]
    private GameObject backpackItemPanel = null;
    [SerializeField]
    private GameObject slotUIElement = null;
    private GameObject inventoryUI = null;

    void Start()
    {
        size = xSize * ySize;
        inventoryUI = GameObject.Find("InventoryUI");

        GameObject _backpackItemPanel = Instantiate(backpackItemPanel, transform.position, Quaternion.identity);
        _backpackItemPanel.transform.SetParent(inventoryUI.transform);
        _backpackItemPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(xSize * 100 + 20, ySize * 100 + 20);
        _backpackItemPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(300, -50);
        for (int i = 0; i < size; i++)
        {
            GameObject _slotUIElement = Instantiate(slotUIElement, transform.position, Quaternion.identity);
            _slotUIElement.transform.SetParent(_backpackItemPanel.transform);
        }
    }
}
