using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EfectoTransparencia : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ----------------------

    [SerializeField] Image[] imagen;

    //---------------------- PROPIEDADES PRIVADAS ---------------------- 

    private float r0;
    private float g0;
    private float b0;
    private float a0;

    private float r1;
    private float g1;
    private float b1;
    private float a1;

    private float r2;
    private float g2;
    private float b2;
    private float a2;

    private float r3;
    private float g3;
    private float b3;
    private float a3;

    void Start()
    {
        r0 = imagen[0].color.r;
        g0 = imagen[0].color.g;
        b0 = imagen[0].color.b;
        a0 = imagen[0].color.a;

        r1 = imagen[1].color.r;
        g1 = imagen[1].color.g;
        b1 = imagen[1].color.b;
        a1 = imagen[1].color.a;

        r2 = imagen[2].color.r;
        g2 = imagen[2].color.g;
        b2 = imagen[2].color.b;
        a2 = imagen[2].color.a;

        r3 = imagen[3].color.r;
        g3 = imagen[3].color.g;
        b3 = imagen[3].color.b;
        a3 = imagen[3].color.a;
    }

    private void Update()
    {

        a0 -= 0.005f;
        a0 = Mathf.Clamp(a0, 0, 1f);
        CambioColor0();

        a1 -= 0.005f;
        a1 = Mathf.Clamp(a1, 0, 1f);
        CambioColor1();

        a2 -= 0.005f;
        a2 = Mathf.Clamp(a2, 0, 1f);
        CambioColor2();

        a3 -= 0.005f;
        a3 = Mathf.Clamp(a3, 0, 1f);
        CambioColor3();
    }

    void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.tag == "bullet")

        {
            a0 += 0.5f;
            a1 += 0.5f;
            a2 += 0.5f;
            a3 += 0.5f;
            Debug.Log("El player fué golpeado por una bala");
        }
    }

    private void CambioColor0()
    {
        Color c = new Color(r0, g0, b0, a0);

        imagen[0].color = c;
    }
    private void CambioColor1()
    {
        Color c = new Color(r1, g1, b1, a1);

        imagen[1].color = c;
    }

    private void CambioColor2()
    {
        Color c = new Color(r2, g2, b2, a2);

        imagen[2].color = c;
    }

    private void CambioColor3()
    {
        Color c = new Color(r3, g3, b3, a3);

        imagen[3].color = c;
    }
}

