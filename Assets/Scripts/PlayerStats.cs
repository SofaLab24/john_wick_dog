using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Update()
    {
        if (!isNotDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"Took {damage} damage.  Current health: {Health}");
        if (Health <= 0 && isNotDead)
        {
            isNotDead = false;
            Debug.Log("GAY!!");
            barsController.PlayerDied();
            //GameObject player = GameObject.FindWithTag("Player");
            //GameObject Go = Instantiate(recall, player.transform.position, Quaternion.identity);
            //Destroy(Go, 8);
            
            //////////////////// restart screen goes here(maybe)
             Time.timeScale = 0f;
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
