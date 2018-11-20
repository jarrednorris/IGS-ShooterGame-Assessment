using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public SpawnPoint[] spawnPoints;

    public void SpawnEnemies()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {

            GameObject.Instantiate(spawnPoints[i].enemyPrefab, spawnPoints[i].point.position, Quaternion.identity);
        }
    }

    [System.Serializable]
    public struct SpawnPoint
    {
        public GameObject enemyPrefab;
        public Transform point;
    }

    private float timer;
    public float spawnInterval = 5;


    private void Update()
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

