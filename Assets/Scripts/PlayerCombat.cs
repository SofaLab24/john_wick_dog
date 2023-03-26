using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public BarsController barsController;
    public WeaponType currentWeapon = WeaponType.None;

    private Movement _movement;
    public GameObject projectile, explosive, ult;

    public float throwForce = 100f;

    public Transform spawnLocation, fartSpawn;

    public GameObject singedFart;
    public GameObject beam;
    public GameObject slash;

    public float fartRate = 0.2f;
    public float fartLife = 5f;

    public int ammoLeft;

    public StateController stateController;
    
    public Vector3 worldPosition;
    Plane plane = new Plane(Vector3.up, 0);

    //public GameObject meeleAttack;

    private bool isAttacking = false;
    private bool attackSet = false;
    public float meeleCooldown = 0.5f;
    public Animator anim;
    PlayerStats stats;

    public Texture2D smokeIcon, johnIcon;
    
    void Start()
    {
        StartCoroutine(spawnFart());
        _movement = GetComponent<Movement>();
        barsController = GameObject.FindWithTag("UI").GetComponent<BarsController>();
        stats = GameObject.FindWithTag("GameController").GetComponent<PlayerStats>();
        stateController = GameObject.FindWithTag("GameController").GetComponent<StateController>();
        StartCoroutine(smokee());

    }

    IEnumerator smokee()
    {
        yield return new WaitForSeconds(.5f);
        barsController.ChangeWeapon(smokeIcon, "Stinky death", 0);
    }

    void Update()
    {
        if (!stateController.isJohn)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (currentWeapon == WeaponType.Projectile)
                {
                    stats.LoseInsanity(2);
                    ammoLeft--;
                    barsController.UpdateAmmo(ammoLeft);
                    GameObject go = Instantiate(projectile, spawnLocation.position,Quaternion.identity);
                
                
                
                    float distance;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (plane.Raycast(ray, out distance))
                    {
                        worldPosition = ray.GetPoint(distance);
                    }
                
                    go.transform.LookAt(new Vector3(worldPosition.x, go.transform.position.y, worldPosition.z));
            
                    go.GetComponent<Rigidbody>().AddForce(go.transform.forward * throwForce);
                    Destroy(go, 3f);
                }
                if (currentWeapon == WeaponType.Explosive)
                {
                    stats.LoseInsanity(3);
                    ammoLeft--;
                    barsController.UpdateAmmo(ammoLeft);
                    GameObject go = Instantiate(explosive, spawnLocation.position,Quaternion.identity);
                
                
                
                    float distance;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (plane.Raycast(ray, out distance))
                    {
                        worldPosition = ray.GetPoint(distance);
                    }
                
                    go.transform.LookAt(new Vector3(worldPosition.x, go.transform.position.y, worldPosition.z));
            
                    go.GetComponent<Rigidbody>().AddForce(go.transform.forward * throwForce);
                    Destroy(go, 3f);
                }
                if (currentWeapon == WeaponType.Ult)
                {
                    stats.LoseInsanity(5);
                    ammoLeft--;
                    barsController.UpdateAmmo(ammoLeft);
                    GameObject go = Instantiate(ult, transform.position,Quaternion.identity);
                    
                    Destroy(go, 2f);
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
            if (!isAttacking)
            {
                barsController.ChangeWeapon(johnIcon, "Pencil", 0);
                StartCoroutine(JohnAttack());
                isAttacking = true;
            }
        }
        
        
    }

    IEnumerator JohnAttack()
    {
        anim.SetTrigger("Attack");
        slash.SetActive(true);
        yield return new WaitForSeconds(meeleCooldown -0.5f);
        slash.SetActive(false);
        yield return new WaitForSeconds(meeleCooldown);
        StartCoroutine(JohnAttack());
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
