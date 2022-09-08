using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigo : MonoBehaviour
{
    [SerializeField] public int vidaMax = 100;
    [SerializeField] public float vidaActual;
    [SerializeField] Image BarraVidaEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        ControlVida(); 
    }

    void ControlVida()
    {
        BarraVidaEnemigo.fillAmount = vidaActual / vidaMax;
    }
}
