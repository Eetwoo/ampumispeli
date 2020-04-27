using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int hp = 100;
    [SerializeField] AudioClip aii;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.transform.tag == "Bullet")
        {
            audioSource.PlayOneShot(aii);

            hp = hp - 50;
            if(hp <= 0)
            {
                Invoke("DespawnEnemy", 2);
            }
        }
    }

    private void DespawnEnemy()
    {
        gameObject.SetActive(false);
    }
}
