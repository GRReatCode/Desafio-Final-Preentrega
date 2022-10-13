using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossBullet : MonoBehaviour
{
    [SerializeField] GameObject impactEffect;
   // [SerializeField] float damage = 25f;
    [SerializeField] GameObject GoundExplosion;
    //[SerializeField] GameObject Collider;

    private void Start()
    {
       
    }
    void OnCollisionEnter(Collision collision)

    {

        ContactPoint contact = collision.contacts[0];

        Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));
        if (collision.gameObject.tag == "Player")
            
        {


            //Health target = collision.transform.gameObject.GetComponent<Health>();
            //target.ApplyDamage(damage);
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
            //Health target = other.transform.gameObject.GetComponent<Health>();
            //target.ApplyDamage(damage);
            Destroy(gameObject);
        }
        
        if (other.gameObject.tag == "Ground")
        {
                      
            Destroy(gameObject);
        }
        


    }




}
