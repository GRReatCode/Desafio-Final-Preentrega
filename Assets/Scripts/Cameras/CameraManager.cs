using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ---------------------

    [SerializeField] GameObject[] cameras;
    [SerializeField] bool CamaraActiva = true;
    

    //---------------------- PROPIEDADES PRIVADAS -------------------------


    void Start()
    {
        
    }

    void Update()
    {

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

    

}
