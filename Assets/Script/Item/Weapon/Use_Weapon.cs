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
    [SerializeField] // zero ergonomics is perfect ergonomics
    private float ergonomics = 0;



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
                var _bullet = Instantiate(bullet, (Vector2)transform.position, transform.rotation);
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {

                    Vector3 accuracyMisplacement = new Vector3(_bullet.transform.rotation.x, _bullet.transform.rotation.y, _bullet.transform.rotation.z + Random.Range(-accuracy + (100 + ergonomics) / 5, accuracy - (100 - ergonomics) / 5));
                    _bullet.transform.rotation = Quaternion.Euler(accuracyMisplacement);
                }
                else
                {
                    Vector3 accuracyMisplacement = new Vector3(_bullet.transform.rotation.x, _bullet.transform.rotation.y, _bullet.transform.rotation.z + Random.Range(-accuracy, accuracy));
                    _bullet.transform.rotation = Quaternion.Euler(accuracyMisplacement);
                }
                timeSinceLastShot = 0;
            }
        }
        if (isSemiAutomatic)
        {
            if (Input.GetAxisRaw("Attack") > 0 && timeSinceLastShot > fireInterval && isAttackAxisInUse == false)
            {
                var _bullet = Instantiate(bullet, (Vector2)transform.position, transform.rotation);
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {

                    Vector3 accuracyMisplacement = new Vector3(_bullet.transform.rotation.x, _bullet.transform.rotation.y, _bullet.transform.rotation.z + Random.Range(-accuracy + (100 + ergonomics) / 5, accuracy - (100 - ergonomics) / 5));
                    _bullet.transform.rotation = Quaternion.Euler(accuracyMisplacement);
                }
                else
                {
                    Vector3 accuracyMisplacement = new Vector3(_bullet.transform.rotation.x, _bullet.transform.rotation.y, _bullet.transform.rotation.z + Random.Range(-accuracy, accuracy));
                    _bullet.transform.rotation = Quaternion.Euler(accuracyMisplacement);
                }
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
                GetComponent<Collider2D>().enabled = true;
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
                    GetComponent<Collider2D>().enabled = false;
                    isAttacking = false;
                }
            }
        }
    }
}
