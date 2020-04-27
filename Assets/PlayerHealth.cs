using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    int playerHP = 200;
    [SerializeField ]private float invincibilityDuration;
    [SerializeField] private float invincibilityDeltaTime;
    private bool IsInvincible = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Enemy" && !IsInvincible)
        {
            
            playerHP = playerHP - 50;
            Debug.Log(playerHP);
            StartCoroutine(BecomeTemporarilyInvicible());
            if (playerHP <= 0)
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
        Debug.Log("invincible");
        IsInvincible = true;

        for(float i = 0; i < invincibilityDuration; i+= invincibilityDeltaTime)
        {
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }


        IsInvincible = false;
        Debug.Log("no longer invincible");
    }
}

