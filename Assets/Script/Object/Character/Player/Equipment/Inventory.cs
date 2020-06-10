using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //avalable slots
    public Container_Object backpackItem = null;
    private GameObject backpackItemPanel = null;
    private GameObject backpackSlot = null;

    [SerializeField]
    private GameObject panelUIElement = null;
    [SerializeField]
    private GameObject slotUIElement = null;

    private GameObject inventoryPanel = null;

    void Start()
    {
        backpackSlot = GameObject.Find("BackpackSlot");
        inventoryPanel = GameObject.Find("inventoryPanel");
        Equip(backpackSlot, backpackItem);
    }

    public void Equip(GameObject containerSlot, Container_Object container)
    {
        GameObject _panelUIElement = Instantiate(panelUIElement, transform.position, Quaternion.identity);
        _panelUIElement.transform.SetParent(inventoryPanel.transform);
        _panelUIElement.GetComponent<RectTransform>().sizeDelta = new Vector2(container.xSize * 100 + 20, container.ySize * 100 + 20);
        _panelUIElement.GetComponent<RectTransform>().anchoredPosition = new Vector2(300, -50);
        _panelUIElement.name = container.type.ToString();
        int size = container.xSize * container.ySize;
        for (int i = 0; i < size; i++)
        {
            GameObject _slotUIElement = Instantiate(slotUIElement, transform.position, Quaternion.identity);
            _slotUIElement.transform.SetParent(_panelUIElement.transform);
            _slotUIElement.name = slotUIElement.name;
        }
        containerSlot.GetComponent<Image>().sprite = container.slotSprite;
        backpackItemPanel = _panelUIElement;
    }

    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in backpackItemPanel.gameObject.transform)
        {
            children.Add(child.gameObject);
        }
        for (int i = 0; i < backpackItem.ItemData.Items.Count; i++)
        {
            if (backpackItem.ItemData.Items[i] != null)
            {
                children[i].transform.GetChild(1).GetComponent<Image>().sprite = backpackItem.database.GetItem[backpackItem.ItemData.Items[i].item.Id].slotSprite;
                if (backpackItem.ItemData.Items[i].amount == 1)
                {
                    children[i].GetComponentInChildren<Text>().text = "";
                }
                else
                {
                    children[i].GetComponentInChildren<Text>().text = backpackItem.ItemData.Items[i].amount.ToString();
                }
            }
        }
    }

    private void OnApplicationQuit()
    {
        backpackItem.ItemData.Items.Clear();
    }

}
