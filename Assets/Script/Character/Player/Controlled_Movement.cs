using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlled_Movement : MonoBehaviour
{
    private Rigidbody2D mainRigid;

    [SerializeField]
    private float multiplier = 1;

    void Start()
    {
        mainRigid = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 move = new Vector2();
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        mainRigid.MovePosition((Vector2)transform.position + move * multiplier * Time.deltaTime);
    }
}
