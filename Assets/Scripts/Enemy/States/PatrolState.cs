using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : StateMachineBehaviour
{
    private float timer;
    private float chaseRange = 8;

    private List<Transform> wayPointsEnemy1 = new List<Transform>();
    private List<Transform> wayPointsEnemy2 = new List<Transform>();
    
    private NavMeshAgent agent;
    private Transform player;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 2f;
        timer = 0;
        GameObject parentObjectEnemy1 = GameObject.Find("WayPointsEnemy1");

        if (parentObjectEnemy1 != null)
        {
            foreach (Transform child in parentObjectEnemy1.transform)
            {
                wayPointsEnemy1.Add(child);
            }
        }
        else
        {
            Debug.LogError("Parent object for Enemy1 not found!");
        }

        GameObject parentObjectEnemy2 = GameObject.Find("WayPointsEnemy2");

        if (parentObjectEnemy2 != null)
        {
            foreach (Transform child in parentObjectEnemy2.transform)
            {
                wayPointsEnemy2.Add(child);
            }
        }
        else
        {
            Debug.LogError("Parent object for Enemy2 not found!");
        }

        if (animator.name == "Enemy1")
        {
            agent.SetDestination(wayPointsEnemy1[Random.Range(0, wayPointsEnemy1.Count)].position);
        }
        else if (animator.name == "Enemy2")
        {
            agent.SetDestination(wayPointsEnemy2[Random.Range(0, wayPointsEnemy2.Count)].position);
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        List<Transform> currentWayPoints = null;
        
        if (animator.name == "Enemy1")
        {
            currentWayPoints = wayPointsEnemy1;
        }
        else if (animator.name == "Enemy2")
        {
            currentWayPoints = wayPointsEnemy2;
        }
        else
        {
            Debug.LogError("Unknown enemy name!");
            return;
        }

        if (currentWayPoints.Count > 0)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
                agent.SetDestination(currentWayPoints[Random.Range(0, currentWayPoints.Count)].position);
        }
        else
        {
            Debug.LogError("No waypoints available for patrolling!");
        }

        timer += Time.deltaTime;
        if (timer > 10)
        {
            animator.SetBool("isPatrolling", false);
        }


        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
        else
        {
            animator.SetBool("isPatrolling", true);
            animator.SetBool("isChasing", false);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
