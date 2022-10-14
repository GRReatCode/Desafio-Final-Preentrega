using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletPower : MonoBehaviour
{
    public GameObject impactEffect;


    //--------------- EVENTOS
    // Se crea un evento para sumar puntos cada vez que la bala colsione con diferentes OBJETOS

    public static event Action OnPowerEnEnemigo;
    public static event Action OnGolpeACaja;
    public static event Action OnGolpeABalas;
    public static event Action OnGolpeAEstatua;
    public static event Action OnGolpeABoos;


    void OnCollisionEnter(Collision collision)

    {

        ContactPoint contact = collision.contacts[0];

        Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));


        //---------------------------------------------------
        // La Bala del PLAYER golpea con OBJETOS del entorno

        if (collision.gameObject.tag == "caja")

        {
            BulletPower.OnGolpeACaja.Invoke();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "EscudoEnemigo")

        {
            Destroy(gameObject);
        }

        //---------------------------------------------------
        // La Bala del PLAYER golpea con otras Balas Enemigas

        if (collision.gameObject.tag == "SpiderBullet")

        {
            BulletPower.OnGolpeABalas.Invoke();
        }

        if (collision.gameObject.tag == "TurretBullet")

        {
            BulletPower.OnGolpeABalas.Invoke();
        }

        if (collision.gameObject.tag == "BoosBullet")

        {
            BulletPower.OnGolpeABalas.Invoke();

        }

        //---------------------------------------------------
        // La Bala del PLAYER golpea con ENEMIGOS

        if (collision.gameObject.tag == "Enemy")

        {
            BulletPower.OnPowerEnEnemigo.Invoke();
        }

        if (collision.gameObject.tag == "Estatua")

        {
            BulletPower.OnGolpeAEstatua.Invoke();
        }

        if (collision.gameObject.tag == "Boos")

        {
            BulletPower.OnGolpeABoos.Invoke();
        }

        Destroy(gameObject);
    }
}
