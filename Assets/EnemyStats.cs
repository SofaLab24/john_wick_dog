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

    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
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
