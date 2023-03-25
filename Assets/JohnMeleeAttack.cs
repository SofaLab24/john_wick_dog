using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMeleeAttack : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("Attack worked");
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();
            
            enemyStats.TakeDamage(50);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("Attack worked trigger");
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();
            
            enemyStats.TakeDamage(50);
        }
    }
}
