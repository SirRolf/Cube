using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Melee,
    FullyAutomatic,
    SemiAutomatic
}
[CreateAssetMenu(fileName = "NewWeapon", menuName = "Object/Item/Weapon", order = 1)]
public class Weapon_Object : Object_Item
{
    //changable values
    [Header("Weapon Type")]
    public WeaponType weaponType;

    [Header("Universal settings")]
    public float fireRate = 0;

    [Header("Melee settings")]
    public List<Quaternion> meleeTargetAngles = new List<Quaternion>();

    [Header("FireArm settings")]
    // The bullet type, houses all the information
    public Bullet_Object bullet_Type;
    // zero accuracy is 100% perfect shot
    public float accuracy = 0;
    [Range(0.0f, 100.0f)] // Higher ergo means less problems
    public float ergonomics = 0;
    // The Recoil can't be higher then this
    public float recoilMax = 0;
    // How fast recoil builds up
    public float recoilGrowth = 0;
    // How fast recoil builds down
    public float recoilRecovery = 0;
    // flash when you shoot
    public GameObject flash;



    //standard values
    private float fireInterval, timeSinceLastShot, recoilCurrent;
    private Quaternion meleeAngle;
    private GameObject player;

    private bool isAttackAxisInUse = false;
    //private bool isAttacking = false;


    public void Equip()
    {
        fireInterval = 60 / fireRate;
        timeSinceLastShot = 0;
        player = GameObject.Find("Player");
    }

    public void Use()
    {
        timeSinceLastShot += Time.deltaTime;
        if (weaponType == WeaponType.FullyAutomatic)
        {
            if (Input.GetAxisRaw("Attack") > 0 && timeSinceLastShot > fireInterval)
            {
                var _bullet = Instantiate(bullet_Type.getProjectile(), (Vector2)player.transform.position, player.transform.rotation);
                Instantiate(flash, _bullet.transform.position, _bullet.transform.rotation);
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    float offset = accuracy + recoilCurrent + (100 + ergonomics) / 5;
                    Vector3 accuracyMisplacement = new Vector3(_bullet.transform.rotation.x, _bullet.transform.rotation.y, _bullet.transform.rotation.z + UnityEngine.Random.Range(offset, -offset));
                    _bullet.transform.rotation *= Quaternion.Euler(accuracyMisplacement);
                }
                else
                {
                    float offset = accuracy + recoilCurrent;
                    Vector3 accuracyMisplacement = new Vector3(_bullet.transform.rotation.x, _bullet.transform.rotation.y, _bullet.transform.rotation.z + UnityEngine.Random.Range(offset, -offset));
                    _bullet.transform.rotation *= Quaternion.Euler(accuracyMisplacement);
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
        if (weaponType == WeaponType.SemiAutomatic)
        {
            if (Input.GetAxisRaw("Attack") > 0 && timeSinceLastShot > fireInterval && isAttackAxisInUse == false)
            {
                var _bullet = Instantiate(bullet_Type.getProjectile(), (Vector2)player.transform.position, player.transform.rotation);
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    float offset = accuracy + recoilCurrent + (100 + ergonomics) / 5;
                    Vector3 accuracyMisplacement = new Vector3(_bullet.transform.rotation.x, _bullet.transform.rotation.y, _bullet.transform.rotation.z + UnityEngine.Random.Range(offset, -offset));
                    _bullet.transform.rotation *= Quaternion.Euler(accuracyMisplacement);
                }
                else
                {
                    float offset = accuracy + recoilCurrent;
                    Vector3 accuracyMisplacement = new Vector3(_bullet.transform.rotation.x, _bullet.transform.rotation.y, _bullet.transform.rotation.z + UnityEngine.Random.Range(offset, -offset));
                    _bullet.transform.rotation *= Quaternion.Euler(accuracyMisplacement);
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
        /*if (weaponType == WeaponType.Melee)
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
        }*/
    }
}
