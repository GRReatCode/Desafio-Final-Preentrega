using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField] public int vidaMax;
    [SerializeField] public float vidaActual;
    [SerializeField] Image barraVida;
    [SerializeField] GameObject enemigo;
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


        if (vidaActual <= vidaMax / 5)
        {
            fuego.SetActive(true);
        }
        else
        {
            fuego.SetActive(false);
        }

        if (vidaActual <= vidaMax / 3)
        {
            humo.SetActive(true);
        }
        else
        {
            humo.SetActive(false);
        }

        if (vidaActual <= 0)
        {
            explosion.SetActive(true);
        }
        else
        {
            explosion.SetActive(false);
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
        // enemigo.GetComponent<MovimientoInferior2>().enabled = false;
        // enemigo.GetComponentInChildren<TurretControl>().enabled = false;
    }
}
