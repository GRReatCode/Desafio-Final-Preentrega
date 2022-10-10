using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoInferior2 : MonoBehaviour
{

    float hMove, vMove;
    [SerializeField] float velocidad;
    [SerializeField] float velocidadGiro;
    [SerializeField] float MultiplicadorVelocidad;
    [SerializeField] float multiplicadorGiro;


    float velocidadActual;
    float velocidadGiroActual;
    // Start is called before the first frame update
    void Start()
    {
        velocidadActual = velocidad;
        velocidadGiroActual = velocidadGiro;

        PowerUpSpeed.OnSpeedUp += MovFast;
        PowerUpSpeed.OnNormalSpeed += NormalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        
        vMove = Input.GetAxis("Vertical") * velocidadActual * Time.deltaTime;

        hMove = Input.GetAxis("Horizontal") * velocidadActual * velocidadGiroActual * Time.deltaTime;

        transform.Rotate(0, hMove, 0);
        transform.Translate(0, 0, vMove);
    }

    void MovFast()
    {

        velocidadActual = velocidad * MultiplicadorVelocidad;
        velocidadGiro = velocidadGiro * multiplicadorGiro;
    }

    void NormalSpeed()
    {

        velocidadActual = velocidad;
        velocidadGiroActual = velocidadGiro;
    }
}
