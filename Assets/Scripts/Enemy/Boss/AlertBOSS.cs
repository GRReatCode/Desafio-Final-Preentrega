using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AlertBOSS : MonoBehaviour
{
    [SerializeField] Image Alert;
    [SerializeField] Animator alert;
    // Start is called before the first frame update
    private void OnEnable()
    {
        //AnimacionInicialBoss.OnAlertBoss += AlertaActiva;
        AnimacionInicialBoss.OnAlertBossD += AlertaDesactiva;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void AlertaActiva()
    {
        alert.SetTrigger("Activado");
    }

    void AlertaDesactiva()
    {
        alert.SetTrigger("Desactivado");
    }

    private void OnDisable()
    {
        //AnimacionInicialBoss.OnAlertBoss -= AlertaActiva;
        AnimacionInicialBoss.OnAlertBossD -= AlertaDesactiva;
    }
}
