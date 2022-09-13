using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEnBoton : MonoBehaviour
{
    //---------------- PROPIEDADES SERIALIZADAS

    [SerializeField] AudioSource FuenteSonido;
    [SerializeField] AudioClip SonidoAReproducir;

    public void SonidoBoton()
    {
        FuenteSonido.clip = SonidoAReproducir;
        FuenteSonido.enabled = false;
        FuenteSonido.enabled = true;
    }
}
