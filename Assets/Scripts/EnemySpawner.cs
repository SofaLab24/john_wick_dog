using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject player;

    public GameObject enemyPrefab;

    public float spawnRate = 1f;
    public int spawnAmount = 2;
    public GameObject[] spawnPoints;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(Spawn());
        StartCoroutine(increaseSpawnRate());
    }

    
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnRate);
        for (int i = 0; i < spawnAmount; i++)
        {
            Instantiate(enemyPrefab, getRandomLocation(), Quaternion.identity);
        }

        StartCoroutine(Spawn());
    }

    Vector3 getRandomLocation()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
    }

    IEnumerator increaseSpawnRate()
    {
        
        spawnAmount++;
        yield return new WaitForSeconds(5);
        StartCoroutine(increaseSpawnRate());
    }
}
