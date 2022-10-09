using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Shield_UI : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ---------------------
    [SerializeField] GameObject IconEscudo;
    [SerializeField]  Image EnergyEscudo;
    [SerializeField]  PowerUpShield duracion;

    float Duracion;
   

    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        EnergyEscudo.fillAmount = duracion.shieldDuration / PowerUpShield.MAXSHIELD;

        if(EnergyEscudo.fillAmount == 0)
        {
            IconEscudo.SetActive(false);
            EnergyEscudo.enabled = false;
        }
        
    }

    
  
}
