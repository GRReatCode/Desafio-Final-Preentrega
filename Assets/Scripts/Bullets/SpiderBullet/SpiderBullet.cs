using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpiderBullet : MonoBehaviour
{
    [SerializeField] GameObject impactEffect;

    // EVENTO - HIT
    // Creo un evento para cuando una bala hace HIT en el player
    public static event Action OnSpiderHitEnPlayer;

    void OnCollisionEnter(Collision collision)

    {
        ContactPoint contact = collision.contacts[0];

        Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));


        if (collision.gameObject.tag == "Player")

        {
            SpiderBullet.OnSpiderHitEnPlayer?.Invoke();
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

