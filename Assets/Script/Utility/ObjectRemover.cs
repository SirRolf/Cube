using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField]
    private float duration = 0;

    private float time = 0;

    void Update()
    {
        time += Time.deltaTime;
        if (time > duration)
        {
            Destroy(gameObject);
        }
    }
}
