using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ContainerData", menuName = "Object/Container", order = 1)]
public class Container_Storage : ScriptableObject
{
    public int xSize = 0;
    public int ySize = 0;

    public GameObject[,] ItemData;

}
