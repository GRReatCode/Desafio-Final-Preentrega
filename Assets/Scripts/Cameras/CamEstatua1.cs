using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CamEstatua1 : MonoBehaviour
{
    [SerializeField] GameObject Camera;
    [SerializeField] float TiempoDeEspera = 4f;

    private void Awake()
    {
        Activador1.OnPuzzle1Active += ActivarCam;
    }

    void Update()
    {
       
    }

    private void ActivarCam()
    {
       StartCoroutine(IniciarAnim());   
    }

    IEnumerator IniciarAnim()
    {
        Camera.SetActive(true);
        yield return new WaitForSeconds(TiempoDeEspera);
        Camera.SetActive(false);
    }
    private void OnDisable()
    {
        Activador1.OnPuzzle1Active -= ActivarCam;
    }
}
