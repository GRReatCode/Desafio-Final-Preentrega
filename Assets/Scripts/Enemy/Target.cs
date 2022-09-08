using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target: MonoBehaviour
{
    [SerializeField] public int vidaMax = 100;
    [SerializeField] public float vidaActual;
    [SerializeField] Image barraVida;


    private void Start()
    {
        vidaActual = vidaMax;
    }


    private void Update()
    {
        RevisarVida();

        if (vidaActual <= 0)
        {
            Die();
        }
    }

    public void RevisarVida()
    {
        barraVida.fillAmount = vidaActual / vidaMax;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
