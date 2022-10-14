using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossBullet : MonoBehaviour
{
    [SerializeField] GameObject impactEffect;
    [SerializeField] GameObject GoundExplosion;


    void OnCollisionEnter(Collision collision)

    {

        ContactPoint contact = collision.contacts[0];

        Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));
        if (collision.gameObject.tag == "Player")
            
        {
            Destroy(gameObject);
        }
            
            
        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(GoundExplosion, contact.point, Quaternion.LookRotation(contact.normal));
            Destroy(gameObject);            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player en Radio");
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Ground")
        {
                      
            Destroy(gameObject);
        }
    }
}
