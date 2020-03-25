using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemDatabase", menuName = "Inventory System/Item/Database", order = 1)]
public class ItemDatabase_Object : ScriptableObject, ISerializationCallbackReceiver
{
    public Object_Item[] items;
    public Dictionary<int, Object_Item> GetItem = new Dictionary<int, Object_Item>();

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].Id = i;
            GetItem.Add(i, items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, Object_Item>();
    }
}
