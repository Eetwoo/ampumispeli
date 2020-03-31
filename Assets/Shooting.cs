using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour


{
    public GameObject bullet;
    public float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*  if (Input.GetKeyDown(KeyCode.Mouse0))
          {
              GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
              Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();
              instBulletRigidBody.AddForce(Vector3.forward * speed); 

    }*/
    }
}
