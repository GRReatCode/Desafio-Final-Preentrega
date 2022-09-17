using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovRuedaIzq : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("movEstatico", true);
        anim.SetBool("movAdelante", false);
        anim.SetBool("movAtras", false);

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("movAdelante",true);
            anim.SetBool("movAtras", false);
            anim.SetBool("movEstatico", false);

            Debug.Log("La cinta gira hacia adelante");
        }
        

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("movAdelante", false);
            anim.SetBool("movAtras", true);
            anim.SetBool("movEstatico", false);
            Debug.Log("La cinta gira hacia atras");
        }

        
            
        
        
    }
}
