using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public WeaponType currentWeapon = WeaponType.None;

    public GameObject projectile;

    public float throwForce = 100f;

    public Transform spawnLocation, fartSpawn;

    public GameObject singedFart;

    public float fartRate = 0.2f;
    public float fartLife = 5f;

    public float ammoLeft;
    
    
    void Start()
    {
        StartCoroutine(spawnFart());
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

        if (ammoLeft<= 0)
        {
            currentWeapon = WeaponType.None;
        }
    }

    IEnumerator spawnFart()
    {
        yield return new WaitForSeconds(fartRate);
        GameObject fart = Instantiate(singedFart, fartSpawn.position, Quaternion.identity);
        Destroy(fart, fartLife);
        StartCoroutine(spawnFart());
    }
}
