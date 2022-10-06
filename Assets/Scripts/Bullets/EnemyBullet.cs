using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ----------------------
    [SerializeField]
    protected EnemyData enemyData;
    [SerializeField] GameObject impactEffect;
    //[SerializeField] float turretdamage = 25f;



    void OnCollisionEnter(Collision collision)

    {
        ContactPoint contact = collision.contacts[0];

        Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));


        if (collision.gameObject.tag == "Player")

        {
            Health target = collision.transform.gameObject.GetComponent<Health>();

            target.ApplyDamage(enemyData.damage);

        }

        Destroy(gameObject);
    }
}
