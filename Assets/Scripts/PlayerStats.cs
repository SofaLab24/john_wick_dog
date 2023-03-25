using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Range(0, 100)]
    public int Health = 100;

    [Range(0, 100)] 
    public int instanity = 100;

    

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"Took {damage} damage.  Current health: {Health}");
        if (Health <= 0)
        {
            Debug.Log("GAY!!");
            Time.timeScale = 0f;
        }
    }

    public void Heal(int value)
    {
        Health += value;
    }
}
