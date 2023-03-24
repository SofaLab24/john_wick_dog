using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;

    private EnemyStats enemyStats;

    private bool isAttacking = false;
    
    
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        enemyStats = GetComponent<EnemyStats>();

        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = Vector3.Distance(transform.position, target.position) < 1f;

        if (!isAttacking)
        {
            agent.SetDestination(target.position);
        }
        else agent.SetDestination(transform.position);
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
