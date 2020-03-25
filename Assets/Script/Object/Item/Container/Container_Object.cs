using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public enum ContainerType
{
    Backpack
}
[CreateAssetMenu(fileName = "NewContainer", menuName = "Object/Item/Container", order = 1)]
public class Container_Object : Object_Item
{

    public string savePath;
    public ItemDatabase_Object database;
    public int xSize = 0;
    public int ySize = 0;

    public ContainerType type;

    public Container ItemData;
    public void AddItem(Item _item, int _amount)
    {
        if (_item.isStackable == false)
        {
            ItemData.Items.Add(new ContainerSlot(_item.Id, _item, _amount));
            Debug.Log("Un stackable");
            return;
        }

        for (int i = 0; i < ItemData.Items.Count; i++)
        {
            if (ItemData.Items[i].item.Id == _item.Id)
            {
                ItemData.Items[i].AddAmount(_amount);
                return;
            }
        }
        ItemData.Items.Add(new ContainerSlot(_item.Id, _item, _amount));
    }

    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, ItemData);
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
        ItemData = (Container)formatter.Deserialize(stream);
        stream.Close();
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        ItemData = new Container();
    }
}

[System.Serializable]
public class Container
{
    public List<ContainerSlot> Items = new List<ContainerSlot>();
}

[System.Serializable]
public class ContainerSlot
{
    public int ID;
    public Item item;
    public int amount;
    public ContainerSlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}
