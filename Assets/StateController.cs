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
        dogState.SetActive(false);
        johnState.SetActive(true);
    }
    public void ChangeToDog()
    {
        dogState.SetActive(true);
        johnState.SetActive(false);
    }
}
