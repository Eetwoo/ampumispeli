using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int maxHealth = 99;
    int currentHealth;
    public HealthBar healthBar;
    [SerializeField] AudioClip aii;
    AudioSource audioSource;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        audioSource = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            //audioSource.PlayOneShot(aii);
            TakeDamage(33);
            
            if(currentHealth <= 0)
            {
                healthBar.gameObject.SetActive(false);
                Invoke("DespawnEnemy", 0.5f);
            }
        }
    }

    private void DespawnEnemy()
    {
        if (gameObject != null)
        {
            // Do something  
            Destroy(gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}   
