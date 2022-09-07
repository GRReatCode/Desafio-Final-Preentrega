using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EfectoSangre : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ----------------------

    [SerializeField] Image EfectoSangreImg;
    //[SerializeField] float Activador = 1f;
    [SerializeField] AudioSource errorSound;

    //---------------------- PROPIEDADES PRIVADAS ---------------------- 

    private float r;
    private float g;
    private float b;
    private float a;

    void Start()
    {
        r = EfectoSangreImg.color.r;
        g = EfectoSangreImg.color.g;
        b = EfectoSangreImg.color.b;
        a = EfectoSangreImg.color.a;
    }

    private void Update()
    {
        
        a -= 0.005f;
        a = Mathf.Clamp(a, 0, 1f);
        CambioColor();
    }

    void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.tag == "bullet")

        {
            a += 0.5f;
            errorSound.Play();
            Debug.Log("El player fué golpeado por una bala");
        }
    }

    private void CambioColor()
    {
        Color c = new Color(r, g, b, a);

        EfectoSangreImg.color = c;
    }
}
