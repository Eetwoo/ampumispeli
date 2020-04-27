using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float delay = 5.0f;
    float canspawn = 5;
    public float randX, randY, randZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if(Time.time >= canspawn)
        {
            randX = UnityEngine.Random.Range(30.0f, 40.0f);
            randY = UnityEngine.Random.Range(1.0f, 2.0f);
            randZ = UnityEngine.Random.Range(-5.0f, 8.0f);

            enemyPrefab = Instantiate(enemyPrefab, new Vector3(randX, randY, randZ), transform.rotation) as GameObject;
            canspawn += delay;
        }
    }
}
