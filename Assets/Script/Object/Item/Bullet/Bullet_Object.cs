using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBullet", menuName = "Object/Item/Bullet", order = 1)]
public class Bullet_Object : Object_Item
{
    public float speed;
    public GameObject impact;
    public GameObject projectile;

    public GameObject getProjectile()
    {
        projectile.GetComponent<BulletMovement>().speed = speed;
        projectile.GetComponent<BulletMovement>().impact = impact;
        return projectile;
    }

}
