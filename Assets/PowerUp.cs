using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;



public class PowerUp : MonoBehaviour
{

    public GameObject pickupEffect;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        if (gameObject.tag == "healthPowerUp")
        {
            GameObject g = GameObject.Find("linna");
            StructureScript st = g.GetComponent<StructureScript>();
            st.TakeDamage(-100);

            PlayerHealth playeri = player.GetComponent<PlayerHealth>();
            playeri.TakeDamage(-100);

        }
        else if (gameObject.tag == "speedPowerUp")
        {
            PlayerMovement stats = player.GetComponent<PlayerMovement>();
            if (stats.speed == 6.0f)
            {
                stats.speed += 6.0f;
            }
        }
        Destroy(gameObject);
    }


}
