using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equiped_Weapons : MonoBehaviour
{
    public List<GameObject> Weapons = new List<GameObject>();

    private int equipedSlot;

    void Start()
    {
        if (Weapons[1] != null)
        {
            equipedSlot = 1;
        }
        else if (Weapons[2] != null)
        {
            equipedSlot = 2;
        }
        else if (Weapons[0] != null)
        {
            equipedSlot = 0;
        }
    }

    void Update()
    {
        if (Weapons[equipedSlot] == null)
        {
            return;
        }
        Weapons[equipedSlot].GetComponent<Use_Weapon>().Use();
    }

    public void ChangeWeapons(GameObject newWeapon, int slot)
    {
        Weapons[slot] = newWeapon;
    }

    public void SwitchWeapon(int slot)
    {
        equipedSlot = slot;
        //start stuff like animations here
    }
}
