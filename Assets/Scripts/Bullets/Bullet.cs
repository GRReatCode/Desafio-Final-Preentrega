using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    protected EnemyData enemyData;
    public GameObject impactEffect;
    //public float playerdamage = 25f;

    void OnCollisionEnter(Collision collision)

    {

        ContactPoint contact = collision.contacts[0];

        Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));

        if (collision.gameObject.tag == "Enemy")

        {

            Target target = collision.transform.gameObject.GetComponent<Target>();

            target.ApplyDamage(enemyData.playerdamage);

        }

        Destroy(gameObject);

        if (collision.gameObject.tag == "Ground")

            Destroy(gameObject);

    }
}
