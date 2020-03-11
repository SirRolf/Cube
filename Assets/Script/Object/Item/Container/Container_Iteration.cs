using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ContainerData", menuName = "Object/Item/Container/Itiration", order = 2)]
public class Container_Iteration : ScriptableObject
{
    public Container_Storage prefab;

    public GameObject[,] ItemData;

    [HideInInspector]
    public new string name;

    [HideInInspector]
    public int xSize;
    [HideInInspector]
    public int ySize;

    void OnEnable()
    {
        name = prefab.name;
        xSize = prefab.xSize;
        ySize = prefab.ySize;
    }
}
