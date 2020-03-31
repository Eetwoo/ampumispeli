using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHealth : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amt)
    {
        print("took damage amount of" + amt.ToString() );
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
