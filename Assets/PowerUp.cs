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
        Debug.Log("powerup picked");
        StructureScript stats = player.GetComponent<StructureScript>();
        stats.currentHealth = stats.currentHealth + 100;
        Destroy(gameObject);
    }
}
