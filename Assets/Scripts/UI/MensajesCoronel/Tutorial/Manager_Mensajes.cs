using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Mensajes : MonoBehaviour
{
    [SerializeField] GameObject avatarCoronel;
    [SerializeField] GameObject ventanaMensaje;
    [SerializeField] GameObject[] lineaDialogo;
    [SerializeField] AudioSource reproductor;
    [SerializeField] AudioClip[] AudioLineaDialogo;


    private int contador = 0;
    private int contador2 = 0;

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
            contador2 = contador2 + 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            contador = contador - 1;
            contador2 = contador2 - 1;
        }

        if (contador == contador2)
        {
            avatarCoronel.SetActive(true);
            ventanaMensaje.SetActive(true);
            lineaDialogo[contador].SetActive(true);
            reproductor.clip = AudioLineaDialogo[contador];
            reproductor.enabled = true;

        }
    }


    private void ApliarVentanaAvatar()
    {

    }

    private void reducirVentanaAvatar()
    {

    }


}
