using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ContainerData", menuName = "Object/Item/Container/Prefab", order = 1)]
public class Container_Storage : ScriptableObject
{
    public new string name;

    public Sprite slotSprite;

    public int xSize = 0;
    public int ySize = 0;

}
