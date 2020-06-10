using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object_Item : ScriptableObject
{
    public Sprite slotSprite;
    public new string name;
    public int Id;
    public bool isStackable;
}

[System.Serializable]
public class Item
{
    public string name;
    public int Id;
    public bool isStackable;
    public Item(Object_Item item)
    {
        name = item.name;
        Id = item.Id;
        isStackable = item.isStackable;
    }
}
