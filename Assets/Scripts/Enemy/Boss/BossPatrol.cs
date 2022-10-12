using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    private int destPoint = 0;
    private NavMeshAgent agent;
    int waypointIndex;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();        
        GotoNextPoint();
    }


    void GotoNextPoint()
    {
       if (waypoints.Length == 0)
            return;        
        agent.destination = waypoints[destPoint].position;
        destPoint = (destPoint + 1) % waypoints.Length;
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
    }


    void Update()
    {
       if (!agent.pathPending && agent.remainingDistance < 0.5f)
       GotoNextPoint();
    }
}

