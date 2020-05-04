//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int maxHealth = 99;
    int dropPowerUp;
    int currentHealth;
    public HealthBar healthBar;
    [SerializeField] AudioClip aii;
    AudioSource audioSource;

    public GameObject spawnPowerUp;

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
                dropPowerUp = Random.Range(0,10);
                Debug.Log("powerup: " + dropPowerUp);
                if (dropPowerUp <= 2)
                {
                    Instantiate(spawnPowerUp, transform.position, transform.rotation);
                } 
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
