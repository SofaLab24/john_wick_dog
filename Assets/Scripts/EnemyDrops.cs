using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDrops : MonoBehaviour
{
    public GameObject[] dropTypes;
    private System.Random rand = new System.Random();

    public void Drop()
    {
        if (rand.Next(2) == 0)
        {
            Instantiate(dropTypes[Random.Range(0, dropTypes.Length)], transform.position, quaternion.identity);
        }
        
    }
}
