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
        position = dogState.gameObject.transform.position;
        
        johnState.SetActive(true);
        johnState.gameObject.transform.position = position;
        dogState.SetActive(false);
        
        ChangeAllStats(true);
        cameraMovement.FindPlayer();
    }
    public void ChangeToDog()
    {
        position = johnState.gameObject.transform.position;
        dogState.SetActive(true);
        dogState.gameObject.transform.position = position;
        johnState.SetActive(false);
        ChangeAllStats(false);
        cameraMovement.FindPlayer();
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
