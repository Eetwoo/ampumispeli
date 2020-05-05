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
    float canspawn = 5;
    float timer;
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
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < Time.time && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            if (NumberOfEnemies >= 0)
            {
                SpawnEnemy();
                Debug.Log("Numberofenemies(if): " + NumberOfEnemies);
                Debug.Log("wavenumber(if): " + WaveNumber);
                Debug.Log("wavenumber(if): " + WaveNumber);
                Debug.Log("timer(if): " + timer);
                Debug.Log("Time.time(if): " + Time.time);
                return;
            }
            else
            {
                ResetWave();
                Debug.Log("Numberofenemies(else): " + NumberOfEnemies);
                Debug.Log("wavenumber(else): " + WaveNumber);
                Debug.Log("timer(else): " + timer);
                Debug.Log("Time.time(else): " + Time.time);
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
      //  if (Time.time >= canspawn)
       // {
            if (WaveNumber <= maxEnemiesBySpawn)
            {
                for (int i = 0; i < WaveNumber; i++)
                {
                    randX = UnityEngine.Random.Range(30.0f, 40.0f);
                    randY = UnityEngine.Random.Range(1.0f, 2.0f);
                    randZ = UnityEngine.Random.Range(-5.0f, 8.0f);

                    enemyPrefab1 = Instantiate(enemyPrefab, new Vector3(randX, randY, randZ), transform.rotation) as GameObject;
                    NumberOfEnemies = NumberOfEnemies - 1;
                    flameejaPrefab1 = Instantiate(flameejaPrefab, new Vector3(randX +2, randY+2, randZ+2), transform.rotation) as GameObject;
                    NumberOfEnemies = NumberOfEnemies - 1;
                timer = Time.time + delay;
            }
                
            }
            
            else
            {
                for (int i = 0; i < maxEnemiesBySpawn; i++)
                {
                    randX = UnityEngine.Random.Range(30.0f, 40.0f);
                    randY = UnityEngine.Random.Range(1.0f, 2.0f);
                    randZ = UnityEngine.Random.Range(-5.0f, 8.0f);

                    enemyPrefab1 = Instantiate(enemyPrefab, new Vector3(randX, randY, randZ), transform.rotation) as GameObject;
                NumberOfEnemies = NumberOfEnemies - 1;
                flameejaPrefab1 = Instantiate(flameejaPrefab, new Vector3(randX + 2, randY + 2, randZ + 2), transform.rotation) as GameObject;

                    NumberOfEnemies = NumberOfEnemies -1 ;
                timer = Time.time + delay;
            }
               
            }
        return;
      //  }
    }
}
