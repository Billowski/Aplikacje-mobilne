using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;

    private PlayerController playerControllerScript;

    private float zSpawn = 65.0f;
    private float xRandom = 0.0f;
    private float yPos = 0.0f;
    private float xEnemySpawnRange = 8.0f;

    private float enemySpawnTime = 2.0f;
    private float enemyDelay = 2.0f;


    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        SpawnEnemy();
        InvokeRepeating("SpawnEnemy", enemyDelay, enemySpawnTime);
    }


    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemies.Length);

        switch (randomIndex)
        {
            case 0:
                xRandom = 0;
                yPos = 0.5f;
                break;
            case 1:
                xRandom = Random.Range(-xEnemySpawnRange + 2, xEnemySpawnRange - 2);
                yPos = 1.5f;
                break;
            case 2:
                xRandom = Random.Range(-xEnemySpawnRange + 1, xEnemySpawnRange - 1);
                yPos = 1.5f;
                break;
        }
        
        Vector3 spawnPos = new Vector3(xRandom, yPos, zSpawn);

        if (playerControllerScript.gameOver == false)
        {
            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].transform.rotation);
        }
    }
}
