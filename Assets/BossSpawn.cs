using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
   public GameObject boss,spawn;

   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player") )
        {
            
            Instantiate(boss, spawn.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
