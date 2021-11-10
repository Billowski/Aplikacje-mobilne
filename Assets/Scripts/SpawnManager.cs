using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] powerups;

    private float zSpawn = 8.0f;
    private float xEnemySpawnRange = 9.0f;
    private float xPowerupSpawnRange = 8.0f;

    private float enemySpawnTime = 3.0f;
    private float enemyDelay = 3.0f;
    private float powerupSpawnTime = 22.5f;
    private float powerupDelay = 13.5f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        InvokeRepeating("SpawnEnemy", enemyDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", powerupDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        float randomX = 0;
        int randomIndex = Random.Range(0, enemies.Length);
        if (randomIndex == 0) {
            randomX = Random.Range(-xEnemySpawnRange, xEnemySpawnRange);
        }
        Vector3 spawnPos = new Vector3(randomX, 0, zSpawn);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].transform.rotation);
    }

    void SpawnPowerup()
    {
        float randomX = Random.Range(-xPowerupSpawnRange, xPowerupSpawnRange);
        int randomIndex = Random.Range(0, powerups.Length);

        Vector3 spawnPos = new Vector3(randomX, 0.5f, zSpawn);

        Instantiate(powerups[randomIndex], spawnPos, powerups[randomIndex].transform.rotation);
    }
}
