using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemDatabase", menuName = "Inventory System/Item/Database", order = 1)]
public class ItemDatabase_Object : ScriptableObject, ISerializationCallbackReceiver
{
    public Object_Item[] items;
    public Dictionary<Object_Item, int> GetId = new Dictionary<Object_Item, int>();
    public Dictionary<int, Object_Item> GetItem = new Dictionary<int, Object_Item>();

    public void OnAfterDeserialize()
    {
        GetId = new Dictionary<Object_Item, int>();
        GetItem = new Dictionary<int, Object_Item>();
        for (int i = 0; i < items.Length; i++)
        {
            GetId.Add(items[i], i);
            GetItem.Add(i, items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
    }
}
