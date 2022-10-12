using System.Collections;
using System.Collections.Generic;
using ArionDigital;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject PantallaGameOver;
    [SerializeField] GameObject cameraGameOver;
    [SerializeField] GameObject imagenSangre;
    [SerializeField] public int vidaMax;
    public float vidaActual;
    [SerializeField] Image barraVida;
    [SerializeField] GameObject player;
    [SerializeField] GameObject humo;
    [SerializeField] GameObject fuego;
    [SerializeField] GameObject explosion;

    public static event Action OnPlayerDie;


    private void Start()
    {
        vidaActual = vidaMax;
        HealthPowerUp.OnHealth += Curar;
    }

    private void Update()
    {
        RevisarVida();
        
    }


    public void RevisarVida()
    {
        barraVida.fillAmount = vidaActual / vidaMax;

        if (vidaActual <= vidaMax / 3)
        {
            player.GetComponent<EfectoSangre>().enabled = true;
        }
        else
        {
            player.GetComponent<EfectoSangre>().enabled = false;
        }

        if (vidaActual <= 0)
        {
            imagenSangre.SetActive(false);
        }
    }



    public void ApplyDamage(float amount)
    {
        vidaActual -= Mathf.Abs(amount);
        if (vidaActual <= 0)
        {            
            Die();
        }
    }

    void Die()
    {
        player.GetComponent<MovimientoInferior2>().enabled = false;
        player.GetComponentInChildren<TurretControl>().enabled = false;
        player.GetComponent<Shooter>().enabled = false;
        humo.SetActive(true);
        fuego.SetActive(true);
        explosion.SetActive(true);
        cameraGameOver.SetActive(true);
        PantallaGameOver.SetActive(true);
        Health.OnPlayerDie.Invoke();

        //Destroy(gameObject);
    }

    private void Curar()
    {
        vidaActual = vidaMax;
    }
}
