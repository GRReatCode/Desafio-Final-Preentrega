using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Activador1 : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ---------------------


    [SerializeField] Animator Escudo1;
    [SerializeField] GameObject Bloqueador;


    // Creo el evento "Se resolvió el puzzle 1"
    public static event Action OnPuzzle1Active;


    //---------------------- PROPIEDADES PRIVADAS ----------------------

        private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CajaActivadora")
        {
            Activador1.OnPuzzle1Active?.Invoke();
            Bloqueador.SetActive(true);
            desactivarEscudo();
        }
    }

    private void desactivarEscudo()
    {
        Escudo1.SetTrigger("DesbloqueoVidrio");
    }

}
