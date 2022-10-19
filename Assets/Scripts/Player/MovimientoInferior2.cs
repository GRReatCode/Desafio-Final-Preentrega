using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoInferior2 : MonoBehaviour
{

    float hMove, vMove;
    [SerializeField] float velocidad;
    [SerializeField] float velocidadGiro;
    [SerializeField] float VelocidadFast;
    [SerializeField] float VelocidadFastGiro;


    float velocidadActual;
    float velocidadGiroActual;


    private void Awake()
    {
        ManagerPlayer.OnFastSpeed += MovFast;
        ManagerPlayer.OnNormalSpeed += NormalSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        velocidadActual = velocidad;
        velocidadGiroActual = velocidadGiro;
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

        velocidadActual = VelocidadFast;
        velocidadGiro = VelocidadFastGiro;
    }

    void NormalSpeed()
    {

        velocidadActual = velocidad;
        velocidadGiroActual = velocidadGiro;
    }

    private void OnDisable()
    {
        ManagerPlayer.OnFastSpeed -= MovFast;
        ManagerPlayer.OnNormalSpeed -= NormalSpeed;
    }
}
