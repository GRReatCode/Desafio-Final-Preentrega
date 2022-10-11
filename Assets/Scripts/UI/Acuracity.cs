using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.Burst.CompilerServices;

public class Acuracity : MonoBehaviour
{
    //------------- Textos en pantalla
    [SerializeField] public int Fired = 1;
    [SerializeField] public int Hit = 1;
    [SerializeField] public TMP_Text TextoAcuracity;
    [SerializeField] public TMP_Text TextoFireHit;
    [SerializeField] public TMP_Text TextoAcuracity2;
    [SerializeField] public TMP_Text TextoFireHit2;
    [SerializeField] public int Punteria;

    //------------- GameObjects animados
    [SerializeField] Animator MissionComplete;
    [SerializeField] Animator Estrella1;
    [SerializeField] Animator Estrella2;
    [SerializeField] Animator Estrella3;

    //------------- Botón Next Mission
    [SerializeField] GameObject MissionC;
    [SerializeField] GameObject ButtonNext;
    


    // Start is called before the first frame update
    void Start()
    {
        Punteria = Hit * 100 / Fired;
        Hit = 1;
        Fired = 1;
        Shooter.OnFired += SumarFired;
        BulletPower.OnGolpeABalas += SumarHit;
        BulletPower.OnGolpeACaja += SumarHit;
        BulletPower.OnGolpeAEstatua += SumarHit;
        BulletPower.OnPowerEnEnemigo += SumarHit;
        Bullet.OnGolpeABalas += SumarHit;
        Bullet.OnGolpeACaja += SumarHit;
        Bullet.OnGolpeAEnemigo += SumarHit;
        Bullet.OnGolpeAEstatua += SumarHit;

        // Evento Estatua derrotada
        HealthStatue.OnDerrotaEnemigo += ActivarFinal;
    }



    // Update is called once per frame
    void Update()
    {
        TextoAcuracity.text = "ACCURACITY " + Hit * 100 / Fired + "%";
        TextoFireHit.text = "FIRED " + Fired + " - HIT " + Hit;

        TextoAcuracity2.text = "ACCURACITY " + Hit * 100 / Fired + "%";
        TextoFireHit2.text = "FIRED " + Fired + " - HIT " + Hit;

        Punteria = Hit * 100 / Fired;
    }

    void SumarFired()
    {
        Fired++;
    }

    void SumarHit()
    {
        Hit++;
    }

    void ActivarFinal()
    {
        if (Punteria < 40)
        {
            StartCoroutine(FinalEstrellas1());
        }

        if (Punteria > 39 && Punteria < 90)
        {
            StartCoroutine(FinalEstrellas2());
        }

        if (Punteria > 89)
        {
            StartCoroutine(FinalEstrellas3());
        }
    }

    IEnumerator FinalEstrellas1()
    {
        yield return new WaitForSeconds(2f);
        MissionC.SetActive(true);
        MissionComplete.SetTrigger("Complete");
        yield return new WaitForSeconds(3f);
        Estrella1.SetTrigger("EstrellaGanada");
        yield return new WaitForSeconds(3f);
        // activo botón de Next Mission
        ButtonNext.SetActive(true);
    }

    IEnumerator FinalEstrellas2()
    {
        yield return new WaitForSeconds(3);
        MissionC.SetActive(true);
        MissionComplete.SetTrigger("Complete");
        yield return new WaitForSeconds(3f);
        Estrella1.SetTrigger("EstrellaGanada");
        yield return new WaitForSeconds(0.5f);
        Estrella2.SetTrigger("EstrellaGanada");
        yield return new WaitForSeconds(3f);
        // activo botón de Next Mission
        ButtonNext.SetActive(true);
    }

    IEnumerator FinalEstrellas3()
    {
        yield return new WaitForSeconds(3f);
        MissionC.SetActive(true);
        MissionComplete.SetTrigger("Complete");
        yield return new WaitForSeconds(3f);
        Estrella1.SetTrigger("EstrellaGanada");
        yield return new WaitForSeconds(0.5f);
        Estrella2.SetTrigger("EstrellaGanada");
        yield return new WaitForSeconds(0.5f);
        Estrella3.SetTrigger("EstrellaGanada");
        yield return new WaitForSeconds(3f);
        // activo botón de Next Mission
        ButtonNext.SetActive(true);
    }

}
