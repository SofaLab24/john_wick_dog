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

    public BarsController barsController;
    public StateController stateController;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"Took {damage} damage.  Current health: {Health}");
        if (Health <= 0)
        {
            Debug.Log("GAY!!");
            Time.timeScale = 0f;
        }
        barsController.UpdateHealthBar(Health);
    }

    public void LoseInsanity(int amount)
    {
        instanity -= amount;
        if (instanity<= 0)
        {
            stateController.ChangeToJohn();
        }
        barsController.UpdateSanityBar(instanity);
    }

    public void GetInsanity(int amount)
    {
        instanity += amount;
        barsController.UpdateSanityBar(instanity);
    }

    public void Heal(int value)
    {
        Health += value;
        barsController.UpdateHealthBar(Health);
    }
}
