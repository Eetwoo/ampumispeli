using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    public HealthBar healthBar;
    [SerializeField] private float invincibilityDuration;
    [SerializeField] private float invincibilityDeltaTime;
    private bool IsInvincible = false;


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
            Debug.Log(currentHealth);
            StartCoroutine(BecomeTemporarilyInvicible());
            if (currentHealth <= 0)
            {
                initGameOver();
            }
        }


    }

    private void initGameOver()
    {
        SceneManager.LoadScene(2);

    }

    private IEnumerator BecomeTemporarilyInvicible()
    {
        Debug.Log("invincible");
        IsInvincible = true;

        for (float i = 0; i < invincibilityDuration; i += invincibilityDeltaTime)
        {
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }


        IsInvincible = false;
        Debug.Log("no longer invincible");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.SetHealth(currentHealth);
    }
}

