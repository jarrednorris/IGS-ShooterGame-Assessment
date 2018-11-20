using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public SpawnPoint[] spawnPoints;

    public void SpawnEnemies() //for each spawn point, spawn an enemy of the type set in the editor gui
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {

            GameObject.Instantiate(spawnPoints[i].enemyPrefab, spawnPoints[i].point.position, Quaternion.identity);
        }
    }

    [System.Serializable]  // create a struct to store enemy types and spawns
    public struct SpawnPoint
    {
        public GameObject enemyPrefab;
        public Transform point;
    }

    private float timer;
    public float spawnInterval = 5; // interval at which enemies respawn


    private void Update() //timer
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0;
            SpawnEnemies();
        }
    }

    private void Awake()
    {
         timer = spawnInterval ;
}
}

