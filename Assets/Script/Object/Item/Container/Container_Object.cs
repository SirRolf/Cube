using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

public enum ContainerType
{
    Backpack
}
[CreateAssetMenu(fileName = "NewContainer", menuName = "Object/Item/Container", order = 1)]
public class Container_Object : Object_Item, ISerializationCallbackReceiver
{

    public string savePath;
    private ItemDatabase_Object database;
    public int xSize = 0;
    public int ySize = 0;

    public ContainerType type;

    private void OnEnable()
    {
#if UNITY_EDITOR
        database = (ItemDatabase_Object)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDatabase_Object));
#else
        database = Resources.Load<ItemDatabase_Object>("Database");
#endif    
    }

    public List<ContainerSlot> ItemData = new List<ContainerSlot>();
    public void AddItem(Object_Item _item, int _amount)
    {
        if (_item.isStackable == false)
        {
            ItemData.Add(new ContainerSlot(database.GetId[_item], _item, _amount));
            return;
        }

        for (int i = 0; i < ItemData.Count; i++)
        {
            if (ItemData[i].item == _item)
            {
                ItemData[i].AddAmount(_amount);
                return;
            }
        }
        ItemData.Add(new ContainerSlot(database.GetId[_item], _item, _amount));
    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < ItemData.Count; i++)
        {
            ItemData[i].item = database.GetItem[ItemData[i].ID];
        }
    }

    public void OnBeforeSerialize()
    {
    }
}

[System.Serializable]
public class ContainerSlot
{
    public int ID;
    public Object_Item item;
    public int amount;
    public ContainerSlot(int _id, Object_Item _item, int _amount)
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
