using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedPU_UI : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ---------------------
    [SerializeField] GameObject IconSpeed;
    [SerializeField] Image EnergySpeed;
    [SerializeField] PowerUpSpeed duracion;

    float Duracion;


    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        EnergySpeed.fillAmount = duracion.speedDuration / PowerUpSpeed.MAXSPEED;

        if (EnergySpeed.fillAmount == 0)
        {
            IconSpeed.SetActive(false);
            EnergySpeed.enabled = false;
        }

    }
}
