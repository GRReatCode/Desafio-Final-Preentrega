using System.Collections;
using System.Collections.Generic;
using ArionDigital;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject PantallaGameOver;
    [SerializeField] GameObject cameraGameOver;
    [SerializeField] GameObject efectoHumo;
    [SerializeField] GameObject efectoFuego;
    [SerializeField] GameObject efectoExplosion;

    public float health = 100f;
    public float damage = 25f;

    private void Start()
    {
        efectoHumo.SetActive(false);
        efectoFuego.SetActive(false);
        efectoExplosion.SetActive(false);
        cameraGameOver.SetActive(false);
        PantallaGameOver.SetActive(false);
    }

    public void ApplyDamage(float amount)
    {
        health -= Mathf.Abs(amount);
        if (health <= 0)
        {            
            Die();
        }

    }

    void Die()
    {
        this.GetComponent<MovimientoInferior2>().enabled = false;
        this.GetComponentInChildren<TurretControl>().enabled = false;
        this.GetComponent<EfectoSangre>().enabled = false;
        this.GetComponent<Shooter>().enabled = false;
        this.GetComponent<Shooter>().enabled = false;
        efectoHumo.SetActive(true);
        efectoFuego.SetActive(true);
        efectoExplosion.SetActive(true);
        cameraGameOver.SetActive(true);
        PantallaGameOver.SetActive(true);
        //Destroy(gameObject);
    }
}
