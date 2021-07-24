using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : MonoBehaviour
{
    public List<Transform> WayPoint = new List<Transform>();
    public NavMeshAgent agent;
    public float patrolSpeed;

    int patrolIndex;
    bool wayPointReached;

    //animationScript
    private EnemyAnimController m_EnemyAnimController;
    public EnemyAnimController EnemyAnimController
    {
        get
        {
            if (m_EnemyAnimController == null)
            {
                m_EnemyAnimController = GetComponent<EnemyAnimController>();
            }
            return m_EnemyAnimController;
        }
    }

    private void Awake()
    {
        patrolIndex = 0;
    }
    public void Patrolling()
    {
        
        if (!wayPointReached)
        {
            agent.speed = patrolSpeed;
            agent.SetDestination(WayPoint[patrolIndex].position);
            EnemyAnimController.walkForward();
        }
        if (wayPointReached)
        {
            //patrol standing
            agent.speed = 0;
            EnemyAnimController.idle();
        }


        //check if waypoint reached
        Vector3 distanceToWalkpoint = transform.position - WayPoint[patrolIndex].position;
        if (distanceToWalkpoint.magnitude < 1.0f && wayPointReached == false)
        {
            wayPointReached = true;
            Invoke(nameof(SwitchNextWayPoint), 2f);
        }

    }

    private void SwitchNextWayPoint()
    {
        patrolIndex++;
        patrolIndex %= WayPoint.Count;
        wayPointReached = false;
    }
}
