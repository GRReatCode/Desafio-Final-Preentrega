using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Activador2 : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ---------------------


    [SerializeField] GameObject Escudo1;
    [SerializeField] Vector3 direction = new Vector3(0f, -1f, 0f);
    [SerializeField] int speed = 6;
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

           
            MagicAudio.Play();
            Camera.SetActive(true);
            Invoke("apagarCamera", TiempoEspera);
            Invoke("Destruction", TiempoEspera);

            // se dispara el evento para sumar un Puzzle
            Activador2.OnPuzzle2Active.Invoke();


            Bloqueador.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "CajaActivadora")
        {
            desactivarEscudo();   
        }
    }

    private void desactivarEscudo()
    {
        Escudo1.transform.position += direction * speed * Time.deltaTime;
    }

    private void apagarCamera()
    {
        Camera.SetActive(false);
    }

    private void Destruction()
    {
        Escudo1.SetActive(false);
    }
}
