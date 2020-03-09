using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Weapon_Flash : MonoBehaviour
{
    UnityEngine.Experimental.Rendering.Universal.Light2D flash;

    void Start()
    {
        flash = this.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        transform.parent.GetComponent<Use_Weapon>().Shoot += Shoot;
    }

    void Update()
    {
        flash.enabled = false;
    }

    private void Shoot()
    {
        flash.enabled = true;
    }
}
