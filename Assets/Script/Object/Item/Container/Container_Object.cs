using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ContainerType
{
    Backpack
}
[CreateAssetMenu(fileName = "NewContainer", menuName = "Object/Item/Container", order = 1)]
public class Container_Object : Object_Item
{
    public int xSize = 0;
    public int ySize = 0;

    public ContainerType type;

    public List<ContainerSlot> ItemData = new List<ContainerSlot>();
    public void AddItem(Object_Item _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < ItemData.Count; i++)
        {
            if (ItemData[i].item == _item)
            {
                ItemData[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (hasItem == false)
        {
            ItemData.Add(new ContainerSlot(_item, _amount));
        }
    }
}

[System.Serializable]
public class ContainerSlot
{
    public Object_Item item;
    public int amount;
    public ContainerSlot(Object_Item _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}
