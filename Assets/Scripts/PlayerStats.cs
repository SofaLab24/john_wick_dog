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
    public GameObject recall;
    public BarsController barsController;
    public StateController stateController;
    private bool isNotDead = true;

    private void Start()
    {
        StartCoroutine(InitialUpdate());
    }

    IEnumerator InitialUpdate()
    {
        
        yield return new WaitForSeconds(.5f);
        barsController.UpdateSanityBar(instanity);
        barsController.UpdateHealthBar(Health);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"Took {damage} damage.  Current health: {Health}");
        if (Health <= 0 && isNotDead)
        {
            isNotDead = false;
            Debug.Log("GAY!!");
            GameObject player = GameObject.FindWithTag("Player");
            Instantiate(recall, player.transform.position, Quaternion.identity);
            //////////////////// restart screen goes here(maybe)
            // Time.timeScale = 0f;
        }
        barsController.UpdateHealthBar(Health);
    }

    public void LoseInsanity(int amount)
    {
        instanity -= amount;
        if (instanity < 0)
        {
            instanity = 0;
        }
        if (instanity<= 0)
        {
            stateController.isJohn = true;
            stateController.ChangeToJohn();
        }
        barsController.UpdateSanityBar(instanity);
    }

    public void GetInsanity(int amount)
    {
        instanity += amount;
        if (instanity > 100)
        {
            instanity = 100;
        }
        
        
        if (instanity>= 100)
        {
            stateController.isJohn = false;
            stateController.ChangeToDog();
        }
        barsController.UpdateSanityBar(instanity);
    }

    public void Heal(int value)
    {
        Health += value;
        barsController.UpdateHealthBar(Health);
    }
}
