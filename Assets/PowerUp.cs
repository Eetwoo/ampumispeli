using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //Debug.Log("powerup picked");
        if (gameObject.tag == "healthPowerUp")
        {
            //StructureScript linna = player.get<>GetComponent<StructureScript>();
            StructureScript linna = GameObject.Find("linna").GetComponent <StructureScript>();

            linna.TakeDamage(-100);
            //linna.currentHealth += 100;
            PlayerHealth playeri = player.GetComponent<PlayerHealth>();
            playeri.TakeDamage(-100);
        }
        else if (gameObject.tag == "speedPowerUp")
        {
            PlayerMovement stats = player.GetComponent<PlayerMovement>();
            stats.speed *= 2;
        }
        Destroy(gameObject);
    }
}