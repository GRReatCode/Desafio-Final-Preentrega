using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurretBullet : MonoBehaviour
{
    [SerializeField] GameObject impactEffect;

    // EVENTO - HIT
    // Creo un evento para cuando una bala hace HIT en el player
    public static event Action OnTurretHitEnPlayer;

    void OnCollisionEnter(Collision collision)

    {

        if (collision.gameObject.tag == "Player")

        {
            TurretBullet.OnTurretHitEnPlayer.Invoke();
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
