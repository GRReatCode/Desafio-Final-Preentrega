using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBullet : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ----------------------
    //[SerializeField] protected EnemyData enemyData;
    [SerializeField] GameObject impactEffect;
    //[SerializeField] float turretdamage = 25f;

    // Creo un evento para cuando una bala hace HIT en el player
    public static event Action OnHitEnPlayer;



    void OnCollisionEnter(Collision collision)

    {
        ContactPoint contact = collision.contacts[0];

        Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));


        if (collision.gameObject.tag == "Player")

        {
            EnemyBullet.OnHitEnPlayer.Invoke();

           // Health target = collision.transform.gameObject.GetComponent<Health>();

           // target.ApplyDamage(enemyData.damage);

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
