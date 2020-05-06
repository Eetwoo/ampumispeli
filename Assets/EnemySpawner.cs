using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab1;
    public GameObject flameejaPrefab;
    public GameObject flameejaPrefab1;
    public GameObject WaveText;
    float delay = 10.0f;
    float timer2;
    float timer;
    float timer3;
    public float randX, randY, randZ;
    int WaveNumber = 1;
    int NumberOfEnemies = 3;
    int enemiesByWave = 3;
    [SerializeField] int moreEnemiesByWave;
    [SerializeField] int maxEnemiesBySpawn;


    // Start is called before the first frame update
    void Start()
    {
        WaveText.GetComponent<Text>().text = "Wave: " + WaveNumber.ToString();
        timer = Time.time + delay;
        timer2 = Time.time + delay + delay;
        timer3 = Time.time + delay + delay + delay;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < Time.time && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            if (NumberOfEnemies >= 0)
            {
                SpawnEnemy();
                return;
            }
            else
            {
                ResetWave();
                return;
            }
        }
        else return;
        
    }

    private void ResetWave()
    {
        enemiesByWave += moreEnemiesByWave;
        NumberOfEnemies = enemiesByWave;
        WaveNumber += 1;
        WaveText.GetComponent<Text>().text = "Wave: " + WaveNumber.ToString();
        
    }

    private void SpawnEnemy()
    {
        SpawnerRight();
        SpawnerTop();
        SpawnerLeft();
    }

    private void SpawnerLeft()
    {
        if (timer3 < Time.time && WaveNumber >= 8)
        {
            if (WaveNumber <= maxEnemiesBySpawn)
            {

                for (int i = 0; i < WaveNumber; i++)
                {

                    RandomizeSpawn2(-18f, -35f, 26f, 0f);
                    SpawnLavaguy();

                    if (WaveNumber >= 8)
                    {
                        SpawnFlameGuy();
                    }
                    timer3 = Time.time + delay + delay + delay;
                }

            }

            else
            {
                for (int i = 0; i < maxEnemiesBySpawn; i++)
                {
                    RandomizeSpawn2(-18f, -35f, 26f, 0f);

                    SpawnLavaguy();

                    if (WaveNumber >= 10)
                    {
                        SpawnFlameGuy();
                    }
                    timer3 = Time.time + delay + delay + delay;
                }

            }
            return;
        }
    }

    private void SpawnerTop()
    {
        if (timer2 < Time.time && WaveNumber >= 2)
        {
            if (WaveNumber <= maxEnemiesBySpawn)
            {
                for (int i = 0; i < WaveNumber; i++)
                {
                    RandomizeSpawn2(30f, -15f, 22f, 30f);
                    SpawnLavaguy();

                    if (WaveNumber >= 5)
                    {
                        SpawnFlameGuy();
                    }
                    timer2 = Time.time + delay + delay;
                }

            }

            else
            {
                for (int i = 0; i < maxEnemiesBySpawn; i++)
                {
                    RandomizeSpawn2(30f, -15f, 22f, 30f);

                    SpawnLavaguy();

                    if (WaveNumber >= 3)
                    {
                        SpawnFlameGuy();
                    }
                    timer2 = Time.time + delay + delay;
                }

            }
            return;
        }
    }
    private void RandomizeSpawn2(float x1, float x2, float z1, float z2 )
    {
        randX = UnityEngine.Random.Range(x1, x2);
        randY = UnityEngine.Random.Range(1.0f, 2.0f);
        randZ = UnityEngine.Random.Range(z1, z2);
    }

    private void SpawnerRight()
    {
        if (WaveNumber <= maxEnemiesBySpawn)
        {
            for (int i = 0; i < WaveNumber; i++)
            {
                RandomizeSpawn();
                SpawnLavaguy();

                if (WaveNumber >= 3)
                {
                    SpawnFlameGuy();
                }
                timer = Time.time + delay;
            }

        }

        else
        {
            for (int i = 0; i < maxEnemiesBySpawn; i++)
            {
                RandomizeSpawn();

                SpawnLavaguy();

                if (WaveNumber >= 3)
                {
                    SpawnFlameGuy();
                }
                timer = Time.time + delay;
            }

        }
        return;
    }

    private void SpawnFlameGuy()
    {
        flameejaPrefab1 = Instantiate(flameejaPrefab, new Vector3(randX + 2, randY + 2, randZ + 2), transform.rotation) as GameObject;
        NumberOfEnemies = NumberOfEnemies - 1;
    }

    private void SpawnLavaguy()
    {
        enemyPrefab1 = Instantiate(enemyPrefab, new Vector3(randX, randY, randZ), transform.rotation) as GameObject;
        NumberOfEnemies = NumberOfEnemies - 1;
    }

    private void RandomizeSpawn()
    {
        randX = UnityEngine.Random.Range(30.0f, 40.0f);
        randY = UnityEngine.Random.Range(1.0f, 2.0f);
        randZ = UnityEngine.Random.Range(-5.0f, 8.0f);
    }
}
