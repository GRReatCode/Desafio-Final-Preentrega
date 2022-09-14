using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaMensajes : MonoBehaviour
{
    [SerializeField] GameObject avatarCoronel;
    [SerializeField] GameObject ventanaMensaje;
    [SerializeField] GameObject[] lineaDialogo;
    [SerializeField] AudioSource reproductor;
    [SerializeField] AudioClip[] AudioLineaDialogo;


    private int contador = 0;


    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            contador = contador + 1; 
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            contador = contador - 1;
        }
    }
}
