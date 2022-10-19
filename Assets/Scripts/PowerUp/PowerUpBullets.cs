using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class PowerUpBullets : MonoBehaviour
{
    //objetos para el powerUp bullet UI
    [SerializeField] public TMP_Text TextoBullets;
    [SerializeField] public int BalasPower = 0;
    [SerializeField] public int BalasTotales = 20;

    

    // Eventos que dice cuando puedo o no disparar balas especiales
    public static event Action OnBulletPower;
    public static event Action OnBulletNormal;

    private void Awake()
    {
        ManagerPlayer.OnPowerUpBullet += SumarBalas;
        Shooter.OnBalaUsada += RestarBala;
    }

    void Start()
    {
        
    }

    private void Update()
    {
        TextoBullets.text = BalasPower + "/" + BalasTotales;

        if (BalasPower <= 0)
        {
            PowerUpBullets.OnBulletNormal?.Invoke();
        }

            if (BalasPower > 0)
        {
            PowerUpBullets.OnBulletPower?.Invoke();
        }
    }

    

    void SumarBalas()
    {
        BalasPower = BalasTotales;
    }

    void RestarBala()
    {
        BalasPower -= 1;
    }

    private void OnDisable()
    {
        ManagerPlayer.OnPowerUpBullet -= SumarBalas;
        Shooter.OnBalaUsada -= RestarBala;
    }
}
