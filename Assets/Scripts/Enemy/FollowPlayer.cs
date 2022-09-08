using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    protected EnemyData enemyData;
    public Transform Player;
    //public float Distance;
    //public float SpeedRotation;
    //public float stopDistance;
    public UnityEngine.AI.NavMeshAgent Enemy;

    RaycastHit objectHit;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, Player.transform.position) < enemyData.Distance)
        {
            Enemy.SetDestination(Player.transform.position);
            Vector3 lTargetDir = Player.transform.position - transform.position;
            lTargetDir.x = enemyData.stopDistance;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * enemyData.SpeedRotation);
        }

    }

}