using System.Collections;
using System.Collections.Generic;
using ArionDigital;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Health : MonoBehaviour
{
    [SerializeField]
    protected EnemyData enemyData;
    
    [SerializeField] GameObject Warning;
    [SerializeField] public int vidaMax;
    [SerializeField] public float vidaActual;
    [SerializeField] Image barraVida;

    //-------------- Propiedades efecto Warning
    [SerializeField] Image Alert;
    [SerializeField] AudioSource errorSound;

    //---------------------- PROPIEDADES PRIVADAS ---------------------- 
    private float r;
    private float g;
    private float b;
    private float a;

    public static event Action OnPlayerDerrotado;


    private void Start()
    {
        vidaActual = vidaMax;
        ManagerPlayer.OnPowerUpHealth += Curar;

        EnemyBullet.OnHitEnPlayer += ApplyDamageSpider;
        TurretBullet.OnHitEnPlayer += ApplyDamageTurret;
        TurretBullet.OnHitEnPlayer += ApplyDamageBoos;

        r = Alert.color.r;
        g = Alert.color.g;
        b = Alert.color.b;
        a = Alert.color.a;
    }

    private void Update()
    {
        RevisarVida();
        a -= 0.005f;
        a = Mathf.Clamp(a, 0, 1f);
        CambioColor();

    }


    public void RevisarVida()
    {
        barraVida.fillAmount = vidaActual / vidaMax;

        if (vidaActual <= vidaMax / 3)
        {
            Warning.SetActive(true);
        }
        else
        {
            Warning.SetActive(false);
        }

        if (vidaActual <= 0)
        {
            Warning.SetActive(false);
        }
    }

    //------------ CURAR - PLAYER

    private void Curar()
    {
        vidaActual = vidaMax;
    }
    //------------ DAÑO ENEMIGO SPIDER - PLAYER

    private void ApplyDamageSpider()
    {
        vidaActual -= enemyData.damage;
        if (vidaActual <= 0)
        {
            Derrotado();
        }
    }
    //------------ DAÑO ENEMIGO TORRETA - PLAYER

    public void ApplyDamageTurret()
    {
        vidaActual -= enemyData.turretdamage;
        if (vidaActual <= 0)
        {
            Derrotado();
        }
    }

    //------------ DAÑO ENEMIGO BOOS FINAL - PLAYER

    public void ApplyDamageBoos()
    {
        vidaActual -= enemyData.turretdamage;
        if (vidaActual <= 0)
        {
            Derrotado();
        }
    }

    //------------ GAME OVER - PLAYER
    void Derrotado()
    {
        Health.OnPlayerDerrotado.Invoke();
    }

    private void CambioColor()
    {
        Color c = new Color(r, g, b, a);

        Alert.color = c;
    }
}
