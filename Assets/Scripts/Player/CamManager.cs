using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    [SerializeField] GameObject[] cameras;
    [SerializeField] bool CamaraActiva = true;
    
   
    void Start()
    {
        AnimacionInicial.OnCamPlayer += ActivarCam3P;
        
    }

    void LateUpdate()
    {

        if (CamaraActiva == true && Input.GetKeyDown(KeyCode.C))
        {
            CamaraActiva = false;
            cameras[1].SetActive(true);
        }
        else if (CamaraActiva == false && Input.GetKeyDown(KeyCode.C))
        {
            CamaraActiva = true;
            cameras[1].SetActive(false);
        }

    }
    private void ActivarCam3P()
    {
        cameras[0].SetActive(true);
    }

    // Update is called once per frame
    
}
