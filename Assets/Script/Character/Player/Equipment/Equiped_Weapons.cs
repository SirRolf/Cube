using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equiped_Weapons : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();

    private int equipedSlot;

    void Start()
    {
        if (weapons[0] != null)
        {
            equipedSlot = 0;
            weapons[equipedSlot].GetComponent<Use_Weapon>().Equip();
        }
        else if (weapons[1] != null)
        {
            equipedSlot = 1;
            weapons[equipedSlot].GetComponent<Use_Weapon>().Equip();
        }
        else if (weapons[2] != null)
        {
            equipedSlot = 2;
            weapons[equipedSlot].GetComponent<Use_Weapon>().Equip();
        }
    }

    void Update()
    {
        if (weapons[equipedSlot] == null)
        {
            print("no Weapon equiped");
            return;
        }
        for (int i = 1; i < 4; i++)
        {
            if (Input.GetAxisRaw("SwitchWeapon" + i) > 0)
            {
                SwitchWeapon(i - 1);
            }
        }
        weapons[equipedSlot].GetComponent<Use_Weapon>().Use();
    }

    public void ChangeWeapons(GameObject newWeapon, int slot)
    {
        weapons[slot] = newWeapon;
    }

    public void SwitchWeapon(int slot)
    {
        print("switching to slot " + slot);
        if (weapons[slot] == null)
        {
            print("empty slot");
            return;
        }
        equipedSlot = slot;
        //start stuff like animations here
    }
}
