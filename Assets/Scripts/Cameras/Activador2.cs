using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Activador2 : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ---------------------


    [SerializeField] Animator Escudo2;
    [SerializeField] GameObject Camera;
    [SerializeField] AudioSource MagicAudio;
    [SerializeField] int TiempoEspera = 4;

    [SerializeField] GameObject Bloqueador;

    // Creo el evento "Se resolvió el puzzle 2"
    public static event Action OnPuzzle2Active;

    //---------------------- PROPIEDADES PRIVADAS ----------------------

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CajaActivadora")
        {
            // se dispara el evento para sumar un Puzzle
            Activador2.OnPuzzle2Active.Invoke();
            StartCoroutine(EscudoDesbloqueado());
            
            

            
            
            
        }
    }

    IEnumerator EscudoDesbloqueado()
    {
        MagicAudio.Play();
        Bloqueador.SetActive(true);
        Camera.SetActive(true);
        Escudo2.SetTrigger("DesbloqueoEscudo");
        yield return new WaitForSeconds(TiempoEspera);
        Camera.SetActive(false);
    }

    
}
