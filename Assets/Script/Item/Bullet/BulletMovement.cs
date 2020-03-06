using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody2D mainRigid;

    [SerializeField]
    private float multiplier = 1;

    void Start()
    {
        mainRigid = this.GetComponent<Rigidbody2D>();
        mainRigid.AddRelativeForce(Vector2.right * multiplier);
    }

    void Update()
    {
        //mainRigid.MovePosition((Vector2)transform.position + Vector2.right * multiplier * Time.deltaTime);
    }
}
