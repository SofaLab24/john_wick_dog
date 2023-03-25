using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public BarsController barsController;
    public WeaponType currentWeapon = WeaponType.None;

    private Movement _movement;
    public GameObject projectile;

    public float throwForce = 100f;

    public Transform spawnLocation, fartSpawn;

    public GameObject singedFart;
    public GameObject beam;

    public float fartRate = 0.2f;
    public float fartLife = 5f;

    public int ammoLeft;

    public StateController stateController;
    
    public Vector3 worldPosition;
    Plane plane = new Plane(Vector3.up, 0);
    
    void Start()
    {
        StartCoroutine(spawnFart());
        _movement = GetComponent<Movement>();
        barsController = GameObject.FindWithTag("UI").GetComponent<BarsController>();
    }

    void Update()
    {
        if (!stateController.isJohn)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (currentWeapon == WeaponType.Projectile)
                {
                
                    ammoLeft--;
                    barsController.UpdateAmmo(ammoLeft);
                    GameObject go = Instantiate(projectile, spawnLocation.position,Quaternion.identity);
                
                
                
                    float distance;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (plane.Raycast(ray, out distance))
                    {
                        worldPosition = ray.GetPoint(distance);
                    }
                
                    Debug.Log(worldPosition);
                    go.transform.LookAt(new Vector3(worldPosition.x, go.transform.position.y, worldPosition.z));
            
                    go.GetComponent<Rigidbody>().AddForce(go.transform.forward * throwForce);
                    Destroy(go, 3f);
                }

            }

            if (Input.GetKey(KeyCode.Mouse0) && currentWeapon == WeaponType.Beam)
            {
                if (currentWeapon == WeaponType.Beam)
                {

                    ammoLeft--;
                    barsController.UpdateAmmo(ammoLeft);
                    GameObject go = Instantiate(beam, spawnLocation);
                    float distance;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (plane.Raycast(ray, out distance))
                    {
                        worldPosition = ray.GetPoint(distance);
                    }

                    Debug.Log("held");
                    go.transform.LookAt(new Vector3(worldPosition.x, go.transform.position.y, worldPosition.z));
                    Destroy(go, 3f);
                }
            }

            if (ammoLeft<= 0)
            {
                currentWeapon = WeaponType.None;
            }
        }
        else
        {
            
        }
        
        
    }

    IEnumerator spawnFart()
    {
        yield return new WaitForSeconds(fartRate);
        if (!stateController.isJohn && _movement.movement.magnitude > 0)
        {
            GameObject fart = Instantiate(singedFart, fartSpawn.position, Quaternion.identity);
            Destroy(fart, fartLife);
        }
        
        StartCoroutine(spawnFart());
    }
}
