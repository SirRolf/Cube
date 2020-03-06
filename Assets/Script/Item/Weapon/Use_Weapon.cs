using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use_Weapon : MonoBehaviour
{
    //changable values
    [Header("Weapon Type")]
    [SerializeField]
    private bool isMelee = false;
    [SerializeField]
    private bool isFullyAutomatic = false;
    [SerializeField]
    private bool isSemiAutomatic = false;

    [Header("Universal settings")]
    [SerializeField]
    private float fireRate = 0;

    [Header("Melee settings")]
    [SerializeField]
    public List<Quaternion> meleeTargetAngles = new List<Quaternion>();

    [Header("FireArm settings")]
    // this is just a normal bullet now but i will make it changable depending on what mag is inserted after a while
    [SerializeField]
    private GameObject bullet = null;




    //standard values
    private float fireInterval, timeSinceLastShot;
    private Quaternion meleeAngle;

    private bool isAttackAxisInUse = false;
    private bool isAttacking = false;

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
            if (Input.GetAxisRaw("Attack") > 0 && timeSinceLastShot > fireInterval && isAttackAxisInUse == false)
            {
                Instantiate(bullet, (Vector2)transform.position, Quaternion.identity);
                timeSinceLastShot = 0;
                isAttackAxisInUse = true;
            }
            if (Input.GetAxisRaw("Attack") == 0)
            {
                isAttackAxisInUse = false;
            }
        }
        if (isMelee)
        {
            if (Input.GetAxisRaw("Attack") > 0 && isAttackAxisInUse == false)
            {
                print("attack is called");
                isAttacking = true;
                for (int i = 0; i < meleeTargetAngles.Capacity; i++)
                {
                    print("now checking what way to go");
                    if (transform.localRotation == meleeTargetAngles[i])
                    {
                        if (i + 1 >= meleeTargetAngles.Capacity)
                        {
                            meleeAngle = meleeTargetAngles[0];
                        }
                        else
                        {
                            meleeAngle = meleeTargetAngles[i + 1];
                        }
                    }
                }
            }
            if (Input.GetAxisRaw("Attack") == 0)
            {
                isAttackAxisInUse = false;
            }
            if (isAttacking)
            {
                print("swinging now");
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, meleeAngle, fireRate * Time.fixedDeltaTime);
                if (transform.localRotation == meleeAngle)
                {
                    isAttacking = false;
                }
            }
        }
    }
}
