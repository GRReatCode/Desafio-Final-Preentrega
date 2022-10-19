using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PowerUpSpeed : MonoBehaviour
{
    // Se debe cambiar el MAXSPEED cuando se cambiemos por inspector el valor de ShieldDuration
    [SerializeField] public float TiempoMax;
    [SerializeField] public float TiempoDuracion;

    [SerializeField] public GameObject IconSpeed;
    [SerializeField] public Image CirculoVida;

    // Eventos que Suben y Bajan la velocidad de Movimiento del player 
    public static event Action OnSpeedUp;
    public static event Action OnNormalSpeed;

    // Eventos que prenden y apagan la linea de contorno del Player
    public static event Action OnOutlineON;
    public static event Action OnOutlineOFF;

    private void Awake()
    {
        ManagerPlayer.OnPowerUpSpeed += ActivarSpeed;
    }
    void Start()
    {
        
    }

    void Update()
    {
        TiempoDuracion -= Time.deltaTime;
        TiempoDuracion = Math.Clamp(TiempoDuracion, 0, TiempoMax);

        CirculoVida.fillAmount = TiempoDuracion / TiempoMax;

        if (CirculoVida.fillAmount == 0)
        {
            IconSpeed.SetActive(false);
            CirculoVida.enabled = false;
        }
    }

    public void ActivarSpeed()
    {
        TiempoDuracion = TiempoMax;
        StartCoroutine(SpeedUp());
        Debug.Log("PowerUp SPEED ACTIVADO");
    }

    public IEnumerator SpeedUp()
    {
        IconSpeed.SetActive(true);
        CirculoVida.enabled = true;
        PowerUpSpeed.OnOutlineON?.Invoke();
        PowerUpSpeed.OnSpeedUp?.Invoke();
       yield return new WaitForSeconds(TiempoMax);
        PowerUpSpeed.OnNormalSpeed?.Invoke();
        PowerUpSpeed.OnOutlineOFF?.Invoke();
        IconSpeed.SetActive(true);
    }

    private void OnDisable()
    {
        ManagerPlayer.OnPowerUpSpeed -= ActivarSpeed;
    }
}
