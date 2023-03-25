using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public BarsController barsController;
    public WeaponType type;
    public int insanityCost = 10;
    public int weaponAmmo = 10;
    private StateController StateController;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player") && !StateController.isJohn)
        {
            
            other.gameObject.GetComponent<PlayerCombat>().currentWeapon = type;
            other.gameObject.GetComponent<PlayerCombat>().ammoLeft = weaponAmmo;
            
            barsController.ChangeWeapon(new Texture2D(256, 256), $"{type}", weaponAmmo);
            
            //other.gameObject.GetComponent<PlayerStats>().LoseInsanity(insanityCost);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StateController = GameObject.FindWithTag("GameController").GetComponent<StateController>();
        barsController = GameObject.FindWithTag("UI").GetComponent<BarsController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
