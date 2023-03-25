using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField]
    private GameObject dogState;

    [SerializeField] private GameObject johnState;

    public bool isJohn;

    private PlayerStats dogStats, johnStats;
    public CameraMovement cameraMovement;
    
    void Start()
    {
        dogStats = dogState.GetComponent<PlayerStats>();
        johnStats = johnState.GetComponent<PlayerStats>();
    }

    
    void Update()
    {
        isJohn = dogStats.instanity <= 0;
        
    }

    public void ChangeToJohn()
    {
        var pos = dogState.transform.position;
        dogState.SetActive(false);
        johnState.SetActive(true);
        johnState.gameObject.transform.position = pos;
        ChangeAllStats(true);
        cameraMovement.FindPlayer();
    }
    public void ChangeToDog()
    {
        var pos = johnState.transform.position;
        dogState.SetActive(true);
        johnState.SetActive(false);
        dogState.gameObject.transform.position = pos;
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
                enemy.GetComponent<EnemyStats>().playerStats = johnStats;
            }
        }
        else
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                enemy.GetComponent<EnemyMovement>().target = dogState.transform;
                enemy.GetComponent<EnemyStats>().playerStats = dogStats;
            }
        }
        
    }
}
