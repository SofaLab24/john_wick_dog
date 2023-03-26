using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Range(0, 500)]
    public int Health = 100;

    [Range(0, 100)] 
    public int damage = 10;

    public float attackRate = 1f;

    PlayerStats playerStats;
    private StateController StateController;


    private void Start()
    {
        playerStats = GameObject.FindWithTag("GameController").GetComponent<PlayerStats>();
        StateController = GameObject.FindWithTag("GameController").GetComponent<StateController>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            if (StateController.isJohn)
            {
                playerStats.GetInsanity(5);
            }
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
