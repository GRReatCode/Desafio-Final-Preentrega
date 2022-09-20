using System.Collections;
using System.Collections.Generic;
using ArionDigital;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject PantallaGameOver;
    [SerializeField] GameObject cameraGameOver;
    [SerializeField] GameObject imagenSangre;
    [SerializeField] public int vidaMax;
    [SerializeField] public float vidaActual;
    [SerializeField] Image barraVida;
    [SerializeField] GameObject player;
    [SerializeField] GameObject humo;
    [SerializeField] GameObject fuego;
    [SerializeField] GameObject explosion;


    private void Start()
    {
        vidaActual = vidaMax;
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
        player.GetComponent<Shooter1>().enabled = false;
        humo.SetActive(true);
        fuego.SetActive(true);
        explosion.SetActive(true);
        cameraGameOver.SetActive(true);
        PantallaGameOver.SetActive(true);
        //Destroy(gameObject);
    }
}
