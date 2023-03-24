using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject player;

    public GameObject enemyPrefab;

    public float spawnRate = 1f;
    public int spawnAmount = 2;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(Spawn());
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
        return new Vector3(Random.Range(-20, 20), 1, Random.Range(-20, 20));
    }
}
