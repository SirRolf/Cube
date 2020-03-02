using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet = null;

    [SerializeField]
    private GameObject currentWeapon;

    void Update()
    {
        if (Input.GetAxisRaw("Attack") > 0)
        {
            Instantiate(bullet, (Vector2)transform.position, Quaternion.identity);
        }
    }
}
