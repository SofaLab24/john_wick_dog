using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    private EnemyStats enemyStats;

    private bool isAttacking = false;

    private Animator anim;



    private void OnTriggerEnter(Collider other)
    {
//        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag.Equals("Fart"))
        {
            if (enemyStats.Health >= 10)
            {
                enemyStats.TakeDamage(10);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (other.gameObject.tag.Equals("Explosive"))
        {
            if (enemyStats.Health >= 50)
            {
                enemyStats.TakeDamage(50);
            }
            else
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }
        
        
    }

    private void OnTriggerStay(Collider other)
    {
        
    }


    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag.Equals("Beam"))
        {
            if (enemyStats.Health >= 10)
            {
                enemyStats.TakeDamage(1);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        enemyStats = GetComponent<EnemyStats>();
        anim = GetComponent<Animator>();
        
        StartCoroutine(Attack());
    }
    

    // Update is called once per frame
    void Update()
    {
        isAttacking = Vector3.Distance(transform.position, target.position) < 1.5f;

        if (!isAttacking)
        {
            agent.SetDestination(target.position);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isAttacking", true);
            anim.SetBool("isWalking", false);
            agent.SetDestination(transform.position);
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(enemyStats.attackRate);
        if (isAttacking)
        {
            enemyStats.DoDamage();
        }

        StartCoroutine(Attack());
    }

}
