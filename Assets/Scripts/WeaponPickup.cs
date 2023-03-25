using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public WeaponType type;
    public int insanityCost = 10;
    public float weaponAmmo = 10;
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayerCombat>().currentWeapon = type;
            other.gameObject.GetComponent<PlayerCombat>().ammoLeft = weaponAmmo;
            
            other.gameObject.GetComponent<PlayerStats>().LoseInsanity(insanityCost);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
