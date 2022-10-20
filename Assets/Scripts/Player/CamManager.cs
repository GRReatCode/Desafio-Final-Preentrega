using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{

    //public static CamManager inst;
    [SerializeField] GameObject[] cameras;
    [SerializeField] bool CamaraActiva = true;

    private void Awake()
    {
        /*if (CamManager.inst == null)
        {
            CamManager.inst = this;
            //DontDestroyOnLoad(gameObject);
        }
        
        else
        {
            Destroy(gameObject);
        }
        */

        AnimacionInicial.OnCamPlayer += ActivarCam3P;
        AnimacionInicialBoss.OnCamPlayer += ActivarCam3P;
    }


    void Start()
    {
        
        
    }

    void LateUpdate()
    {

        if (CamaraActiva == true && Input.GetKeyDown(KeyCode.C))
        {
            CamaraActiva = false;
            cameras[1].SetActive(true);
            cameras[0].SetActive(false);
        }
        else if (CamaraActiva == false && Input.GetKeyDown(KeyCode.C))
        {
            CamaraActiva = true;
            cameras[0].SetActive(true);
            cameras[1].SetActive(false);
        }

    }
    private void ActivarCam3P()
    {
        cameras[0].SetActive(true);
    }

    private void OnDisable()
    {
        AnimacionInicial.OnCamPlayer -= ActivarCam3P;
        AnimacionInicialBoss.OnCamPlayer -= ActivarCam3P;
    }

}
