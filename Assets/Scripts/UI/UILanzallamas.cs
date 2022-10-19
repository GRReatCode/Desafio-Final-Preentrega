using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UILanzallamas : MonoBehaviour
{
    
    [SerializeField] Image BarraFuego;
    [SerializeField] float CargaMaxima;
    [SerializeField] float RecargaFuel;
    [SerializeField] float ConsumoFuel;
    public static event Action OnShoot;
    public static event Action OnStopShooting;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BarraFuego.fillAmount += RecargaFuel / CargaMaxima;

        if (Input.GetMouseButton(1))
        {
            UILanzallamas.OnShoot?.Invoke();
            BarraFuego.fillAmount -= ConsumoFuel / CargaMaxima;
            if (BarraFuego.fillAmount == 0)
            {
                UILanzallamas.OnStopShooting?.Invoke();
            }

        }
        else
        {
            UILanzallamas.OnStopShooting?.Invoke();
        }
    }
}
