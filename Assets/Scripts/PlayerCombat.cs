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

    public StateController stateController;
    
    
    void Start()
    {
        StartCoroutine(spawnFart());
    }

    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (currentWeapon == WeaponType.Projectile)
            {
                
                ammoLeft--;
                GameObject go = Instantiate(projectile, spawnLocation.position,Quaternion.identity);
                
                
                // Ray ray = Camera.main.ScreenPointToRay(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                // if (Physics.Raycast(ray, out RaycastHit raycastHit))
                // {
                //     go.transform.LookAt(new Vector3(raycastHit.point.x, go.transform.position.y, raycastHit.point.z));
                // }
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                go.transform.LookAt(new Vector3(mousePos.x, go.transform.position.y, mousePos.z));
            
                
                
                
                go.GetComponent<Rigidbody>().AddForce(go.transform.forward * throwForce);
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
        if (!stateController.isJohn)
        {
            GameObject fart = Instantiate(singedFart, fartSpawn.position, Quaternion.identity);
            Destroy(fart, fartLife);
        }
        
        StartCoroutine(spawnFart());
    }
}
