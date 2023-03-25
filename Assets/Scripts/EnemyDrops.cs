using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDrops : MonoBehaviour
{
    public GameObject[] dropTypes;


    public void Drop()
    {
        if (Random.Range(0,5) == 3)
        {
            Instantiate(dropTypes[Random.Range(0, dropTypes.Length)], transform.position, quaternion.identity);
        }
        
    }
}
