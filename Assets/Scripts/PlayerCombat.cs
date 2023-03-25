using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public WeaponType currentWeapon = WeaponType.None;

    public GameObject projectile;

    public float throwForce = 100f;

    public Transform spawnLocation;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (currentWeapon == WeaponType.Projectile)
            {
                GameObject go = Instantiate(projectile, spawnLocation.position,Quaternion.identity);
                go.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
                Destroy(go, 3f);
            }
        }
    }
}
