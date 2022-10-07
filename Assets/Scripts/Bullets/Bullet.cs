using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    protected EnemyData enemyData;
    public GameObject impactEffect;
    //public float playerdamage = 25f;


    // Se crea un evento para sumar puntos cada vez que la bala colsione con un objeto distinto

    public static event Action OnGolpeAEnemigo;
    public static event Action OnGolpeACaja;
    public static event Action OnGolpeABalas;

    [SerializeField]

    void OnCollisionEnter(Collision collision)

    {

        ContactPoint contact = collision.contacts[0];

        Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));

        if (collision.gameObject.tag == "Enemy")

        {
            Target target = collision.transform.gameObject.GetComponent<Target>();

            // restamos vida al enemigo
            target.ApplyDamage(enemyData.playerdamage);

            // invocamos el evento para que se suscriban...
            Bullet.OnGolpeAEnemigo.Invoke();
        }


        if (collision.gameObject.tag == "caja")

        {
            // invocamos el evento para que se suscriban...
            Bullet.OnGolpeACaja.Invoke();
        }

        if (collision.gameObject.tag == "Bullet")

        {
            // invocamos el evento para que se suscriban...
            Bullet.OnGolpeABalas.Invoke();
        }

        Destroy(gameObject);
    }
}
