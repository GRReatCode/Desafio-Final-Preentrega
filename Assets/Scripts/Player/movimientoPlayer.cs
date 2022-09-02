using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPlayer : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ---------------------

    [SerializeField] float Velocidad = 8f;


    //---------------------- PROPIEDADES PRIVADAS ---------------------


    void Update()
    {
        
        if(Input.GetKey(KeyCode.W))
        {
            MoverJugador(Vector3.forward);
            Debug.Log("Me muevo hacia adelante");
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoverJugador(Vector3.back);
            Debug.Log("Me muevo hacia atrás");
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoverJugador(Vector3.left);
            Debug.Log("Me muevo hacia la izquierda");
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoverJugador(Vector3.right);
            Debug.Log("Me muevo hacia la derecha");
        }

        void MoverJugador(Vector3 direction)
        {
        transform.Translate(direction * Velocidad * Time.deltaTime);
        }
    } 
}
