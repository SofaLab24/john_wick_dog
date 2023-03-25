using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Range(0, 100)]
    public int Health = 100;

    [Range(0, 100)] 
    public int damage = 10;

    public float attackRate = 1f;

    public PlayerStats playerStats;


    private void Start()
    {
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            GetComponent<EnemyDrops>().Drop();
            Destroy(gameObject);
        }
    }

    public void Heal(int value)
    {
        Health += value;
    }

    public void DoDamage()
    {
        playerStats.TakeDamage(damage);
    }

    
}
