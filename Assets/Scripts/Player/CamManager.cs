using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    [SerializeField] GameObject cam3P;
    [SerializeField] GameObject camSup;
    // Start is called before the first frame update
    void Start()
    {
        AnimacionInicial.OnCamPlayer += ActivarCam3P;
    }

    void Update()
    {
        
    }
    private void ActivarCam3P()
    {
        cam3P.SetActive(true);
    }

    // Update is called once per frame
    
}
