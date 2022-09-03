using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMov_01 : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ----------------------

    [SerializeField] float mousePosX;
    [SerializeField] float mousePosY;
    [SerializeField] float movimientoX = 20f;
    [SerializeField] float movimientoY = 20f;
    //---------------------- PROPIEDADES PRIVADAS -------------------------


    void Start()
    {
        
    }

   
    void Update()
    {
        mousePosX = Input.mousePosition.x;
        mousePosY = Input.mousePosition.y;

        this.GetComponent<RectTransform>().position = new Vector2(
            (mousePosX / Screen.width)* movimientoX + (Screen.width / 2),
            (mousePosY / Screen.height) * movimientoY + (Screen.height / 2));
    }
}
