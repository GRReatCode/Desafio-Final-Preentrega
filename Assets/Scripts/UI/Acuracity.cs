using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.Burst.CompilerServices;

public class Acuracity : MonoBehaviour
{

    [SerializeField] public int Fired = 0;
    [SerializeField] public int Hit = 0;
    [SerializeField] public TMP_Text TextoAcuracity;
    [SerializeField] public TMP_Text TextoFireHit;
    [SerializeField] public TMP_Text TextoAcuracity2;
    [SerializeField] public TMP_Text TextoFireHit2;
    [SerializeField] public int Punteria;
    

    // Start is called before the first frame update
    void Start()
    {
        Punteria = Hit * 100 / Fired;
        Hit = 0;
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
    }



    // Update is called once per frame
    void Update()
    {
        TextoAcuracity.text = "ACURACITY " + Hit * 100 / Fired + "%";
        TextoFireHit.text = "FIRED " + Fired + " - HIT " + Hit;

        TextoAcuracity2.text = "ACURACITY " + Hit * 100 / Fired + "%";
        TextoFireHit2.text = "FIRED " + Fired + " - HIT " + Hit;
        
    }

    void SumarFired()
    {
        Fired++;
    }

    void SumarHit()
    {
        Hit++;
    }
}
