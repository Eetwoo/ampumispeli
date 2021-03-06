﻿//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int dropPowerUp;
    int currentHealth;
    public HealthBar healthBar;
    [SerializeField] AudioClip aii;
    AudioSource audioSource;

    public GameObject healthPowerUp;
    public GameObject speedPowerUp;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        audioSource = GetComponent<AudioSource>();

    }
    private void Update()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(1))
        {
            DespawnEnemy();
        }
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
                dropPowerUp = Random.Range(0,20);
                Debug.Log("powerup: " + dropPowerUp);
                if (dropPowerUp <= 1)
                {
                    Instantiate(healthPowerUp, transform.position, transform.rotation);
                }
                else if (dropPowerUp <= 2)
                {
                    Instantiate(speedPowerUp, transform.position, transform.rotation);
                }
                Invoke("DespawnEnemy", 0.00000000000001f);
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
