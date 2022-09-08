using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroBarraVida : MonoBehaviour
{
    void Update()
    {
        //--- Giro de la Barra de Vida siempre mirando hacia la cámara activa
        transform.forward = Camera.main.transform.forward;
    }
}
