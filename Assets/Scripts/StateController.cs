using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] private GameObject dogState;

    [SerializeField] private GameObject johnState;

    public bool isJohn;

    private PlayerStats stats;
    public CameraMovement cameraMovement;

    private Vector3 position;

    
    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    

    public void ChangeToJohn()
    {
        StartCoroutine(stopMovementJohn());
        johnState.gameObject.GetComponent<Movement>().enabled = false;
        johnState.SetActive(true);
        
        
        position = dogState.transform.position;
        johnState.transform.position = position;
        dogState.SetActive(false);
        
        ChangeAllStats(true);
        cameraMovement.FindPlayer();
        //johnState.gameObject.GetComponent<Movement>().enabled = true;
    }
    public void ChangeToDog()
    {
        StartCoroutine(stopMovementDog());
        position = johnState.gameObject.transform.position;
        dogState.SetActive(true);
        dogState.gameObject.transform.position = position;
        johnState.SetActive(false);
        ChangeAllStats(false);
        cameraMovement.FindPlayer();
    }

    IEnumerator stopMovementJohn()
    {
        johnState.gameObject.GetComponent<Movement>().enabled = false;
        yield return new WaitForSeconds(1f);
        johnState.gameObject.GetComponent<Movement>().enabled = true;
    }
    
    IEnumerator stopMovementDog()
    {
        dogState.gameObject.GetComponent<Movement>().enabled = false;
        yield return new WaitForSeconds(1f);
        dogState.gameObject.GetComponent<Movement>().enabled = true;
    }

    void ChangeAllStats(bool isJohn)
    {
        if (isJohn)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                enemy.GetComponent<EnemyMovement>().target = johnState.transform;
            }
        }
        else
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                enemy.GetComponent<EnemyMovement>().target = dogState.transform;
            }
        }
        
    }
}
