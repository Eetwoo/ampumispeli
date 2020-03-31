using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] AudioClip aii;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        if(collision.transform.tag == "Enemy")
        {
            audioSource.PlayOneShot(aii);
            Destroy(collision.gameObject);
            Invoke("DespawnBullet", 2);

        }


    }

    private void DespawnBullet()
    {
       gameObject.SetActive(false);
    }
}
