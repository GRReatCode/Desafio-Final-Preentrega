using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurretBullet : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ----------------------
    [SerializeField]
    protected EnemyData enemyData;
    [SerializeField] GameObject impactEffect;
    //[SerializeField] float turretdamage = 25f;

    // Creo un evento para cuando una bala hace HIT en el player
    public static event Action OnHitEnPlayer;

    void OnCollisionEnter(Collision collision)

    {

        if (collision.gameObject.tag == "Player")

        {
            TurretBullet.OnHitEnPlayer.Invoke();
            // Health target = collision.transform.gameObject.GetComponent<Health>();
            // target.ApplyDamage(enemyData.turretdamage);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
    }
}
