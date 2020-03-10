using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Vector2 currentLocation = new Vector2(0,0);

    [SerializeField]
    private float speed = 1;

    void Start()
    {
        currentLocation = transform.position;
        print(currentLocation);
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Linecast(currentLocation, currentLocation + (Vector2)transform.right * speed);
        currentLocation += (Vector2)transform.right * speed;
        print(currentLocation);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "HighCover")
            {
                Destroy(gameObject);
            }
        }
        Debug.DrawLine(currentLocation, currentLocation + (Vector2)transform.right * speed);
    }
}
