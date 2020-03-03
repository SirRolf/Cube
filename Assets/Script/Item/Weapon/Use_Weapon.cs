using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use_Weapon : MonoBehaviour
{
    [SerializeField]
    private bool isMelee, isFullyAutomatic;

    [SerializeField]
    private int fireRate;

    // this is just a normal bullet now but i will make it changable depending on what mag is inserted after a while
    [SerializeField]
    private GameObject bullet = null;

    public void Use()
    {
        if (Input.GetAxisRaw("Attack") > 0)
        {
            Instantiate(bullet, (Vector2)transform.position, Quaternion.identity);
        }
    }
}
