using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use_Weapon : MonoBehaviour
{
    [SerializeField]
    private bool isMelee = false, isFullyAutomatic = false, isSemiAutomatic = false;

    [SerializeField]
    private float fireRate = 0;

    private float fireInterval, timeSinceLastShot;

    private bool isAttackAxisInUse = false;

    // this is just a normal bullet now but i will make it changable depending on what mag is inserted after a while
    [SerializeField]
    private GameObject bullet = null;

    public void Equip()
    {
        fireInterval = 60 / fireRate;
        timeSinceLastShot = 0;
    }

    public void Use()
    {
        timeSinceLastShot += Time.deltaTime;
        if (isFullyAutomatic)
        {
            if (Input.GetAxisRaw("Attack") > 0 && timeSinceLastShot > fireInterval)
            {
                Instantiate(bullet, (Vector2)transform.position, Quaternion.identity);
                timeSinceLastShot = 0;
            }
        }
        if (isSemiAutomatic)
        {
            if (Input.GetAxisRaw("Attack") > 0 && timeSinceLastShot > fireInterval)
            {
                if (isAttackAxisInUse == false)
                {
                    Instantiate(bullet, (Vector2)transform.position, Quaternion.identity);
                    timeSinceLastShot = 0;
                    isAttackAxisInUse = true;
                }
            }
            if (Input.GetAxisRaw("Attack") == 0)
            {
                isAttackAxisInUse = false;
            }
        }
        if (isMelee)
        {
            if (Input.GetAxisRaw("Attack") > 0 && timeSinceLastShot > fireInterval)
            {
                //should move the item
            }
        }
    }
}
