using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //avalable slots
    [SerializeField]
    private GameObject backpackSlot = null;

    private GameObject backpackSlotUI = null;

    void Start()
    {
        backpackSlotUI = GameObject.Find("BackpackSlot");
    }
}
