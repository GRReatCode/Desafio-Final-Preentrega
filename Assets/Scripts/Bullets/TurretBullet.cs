using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ----------------------
    [SerializeField]
    protected EnemyData enemyData;
    [SerializeField] GameObject impactEffect;
    //[SerializeField] float turretdamage = 25f;



    void OnCollisionEnter(Collision collision)

    {

        if (collision.gameObject.tag == "Player")

        {
            Health target = collision.transform.gameObject.GetComponent<Health>();

            target.ApplyDamage(enemyData.turretdamage);
        }

        Destroy(gameObject);
    }
}
