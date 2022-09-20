using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    protected EnemyData enemyData;
    public Transform Player;
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
            Attack();
        }

        float dist = Vector3.Distance(transform.position, Player.transform.position);
        if (dist < enemyData.stopDistance)
        {
            StopEnemy();
        }

    }
    private void Attack()
    {
        Enemy.isStopped = false;
        Enemy.SetDestination(Player.transform.position);
        Debug.Log("attack");
    }
    private void StopEnemy()
    {
        Enemy.isStopped = true;
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player Bullet"))
        {
            Attack();
        }
    }

}