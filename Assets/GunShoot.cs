using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public Camera cam;
    public float damage;
    public float range;
    public float impactForce;
    public float fireRate;
    float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot();
        }
    }

    void shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast (cam.transform.position, cam.transform.forward, out hit , range))
        {
            TargetHealth target = hit.transform.GetComponent<TargetHealth>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}
