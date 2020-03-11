using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Vector2 currentLocation = new Vector2(0,0);

    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private GameObject impact = null;

    void Start()
    {
        currentLocation = transform.position;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Linecast(currentLocation, currentLocation + (Vector2)transform.right * speed);
        currentLocation += (Vector2)transform.right * speed;
        if (hit.collider != null)
        {
            if (hit.collider.tag == "HighCover")
            {
                if (impact != null)
                {
                    Instantiate(impact, hit.point, transform.rotation);
                }
                Destroy(gameObject);
            }
        }
    }
}
