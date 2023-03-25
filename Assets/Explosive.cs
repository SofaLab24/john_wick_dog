using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public GameObject explosiveTrigger, particle;
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.tag.Equals("Player"))
        {
            explosiveTrigger.SetActive(true);
            particle.SetActive(true);
        }
        
    }
}
