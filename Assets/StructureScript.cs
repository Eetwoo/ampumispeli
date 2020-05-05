using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StructureScript : MonoBehaviour
{
    [SerializeField] private float invincibilityDuration;
    [SerializeField] private float invincibilityDeltaTime;
    private bool IsInvincible = false;
    
    
    public int maxHealth = 500;
    public int currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {       
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Enemy" && !IsInvincible)
        {
            TakeDamage(50);
            StartCoroutine(BecomeTemporarilyInvicible());                     
            
            if (currentHealth <= 0)
                
                {
                    initGameOver();
                }
    }

}

    private void initGameOver()
    {
        SceneManager.LoadScene(0);

    }

    private IEnumerator BecomeTemporarilyInvicible()
    {
        IsInvincible = true;

        for (float i = 0; i < invincibilityDuration; i += invincibilityDeltaTime)
        {
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }


        IsInvincible = false;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
