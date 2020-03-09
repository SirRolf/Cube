using System;
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
    [SerializeField] // zero accuracy is 100% perfect shot
    private float accuracy = 0;
    [SerializeField] [Range(0.0f, 100.0f)] // Higher ergo means less problems
    private float ergonomics = 0;
    [SerializeField] // The Recoil can't be higher then this
    private float recoilMax = 0;
    [SerializeField] // How fast recoil builds up
    private float recoilGrowth = 0;
    [SerializeField] // How fast recoil builds down
    private float recoilRecovery = 0;



    //standard values
    private float fireInterval, timeSinceLastShot, recoilCurrent;
    private Quaternion meleeAngle;

    private bool isAttackAxisInUse = false;
    private bool isAttacking = false;

    //Delegates
    public event Action Shoot;

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
                Shoot();
                var _bullet = Instantiate(bullet, (Vector2)transform.position, transform.rotation);
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    float offset = accuracy + recoilCurrent + (100 + ergonomics) / 5;
                    Vector3 accuracyMisplacement = new Vector3(_bullet.transform.rotation.x, _bullet.transform.rotation.y, _bullet.transform.rotation.z + UnityEngine.Random.Range(offset, -offset));
                    _bullet.transform.rotation = Quaternion.Euler(accuracyMisplacement);
                }
                else
                {
                    float offset = accuracy + recoilCurrent;
                    Vector3 accuracyMisplacement = new Vector3(_bullet.transform.rotation.x, _bullet.transform.rotation.y, _bullet.transform.rotation.z + UnityEngine.Random.Range(offset, -offset));
                    _bullet.transform.rotation = Quaternion.Euler(accuracyMisplacement);
                }
                if (recoilCurrent < recoilMax)
                {
                    recoilCurrent += recoilGrowth;
                }
                timeSinceLastShot = 0;
            }
            if (recoilCurrent > 0)
            {
                recoilCurrent -= recoilRecovery * Time.deltaTime;
            }
            else if (recoilCurrent != 0)
            {
                recoilCurrent = 0;
            }
        }
        if (isSemiAutomatic)
        {
            if (Input.GetAxisRaw("Attack") > 0 && timeSinceLastShot > fireInterval && isAttackAxisInUse == false)
            {
                Shoot();
                var _bullet = Instantiate(bullet, (Vector2)transform.position, transform.rotation);
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    float offset = accuracy + recoilCurrent + (100 + ergonomics) / 5;
                    Vector3 accuracyMisplacement = new Vector3(_bullet.transform.rotation.x, _bullet.transform.rotation.y, _bullet.transform.rotation.z + UnityEngine.Random.Range(offset, -offset));
                    _bullet.transform.rotation = Quaternion.Euler(accuracyMisplacement);
                }
                else
                {
                    float offset = accuracy + recoilCurrent;
                    Vector3 accuracyMisplacement = new Vector3(_bullet.transform.rotation.x, _bullet.transform.rotation.y, _bullet.transform.rotation.z + UnityEngine.Random.Range(offset, -offset));
                    _bullet.transform.rotation = Quaternion.Euler(accuracyMisplacement);
                }
                if (recoilCurrent < recoilMax)
                {
                    recoilCurrent += recoilGrowth;
                }
                timeSinceLastShot = 0;
                isAttackAxisInUse = true;
            }
            if (Input.GetAxisRaw("Attack") == 0)
            {
                if (recoilCurrent > 0)
                {
                    recoilCurrent -= recoilRecovery * Time.deltaTime;
                }
                else if (recoilCurrent != 0)
                {
                    recoilCurrent = 0;
                }
                isAttackAxisInUse = false;
            }
        }
        if (isMelee)
        {
            if (Input.GetAxisRaw("Attack") > 0 && isAttackAxisInUse == false)
            {
                isAttacking = true;
                GetComponent<Collider2D>().enabled = true;
                for (int i = 0; i < meleeTargetAngles.Capacity; i++)
                {
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
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, meleeAngle, fireRate * Time.fixedDeltaTime);
                if (transform.localRotation == meleeAngle)
                {
                    GetComponent<Collider2D>().enabled = false;
                    isAttacking = false;
                }
            }
        }
    }
}
