using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PowerUpShield : MonoBehaviour
{
    // Se debe cambiar el MAXSHILD cuando se cambiemos por inspector el valor de ShieldDuration
    public float TiempoMAX = 20;
    public float TiempoDuracion;
    public GameObject IconEscudo;
    [SerializeField] Image CirculoVida;
    

    public static event Action OnActivarMesh;
    public static event Action OnActivarCollider;

    public static event Action OnDesactivarMesh;
    public static event Action OnDesactivarCollider;


    public static event Action OnAumentarEscala;
    public static event Action OnReducirEscala;

    // Start is called before the first frame update
    void Start()
    {
        ManagerPlayer.OnPowerUpShield += EscudoActivo;
    }

    // Update is called once per frame
    void Update()
    {
        TiempoDuracion -= Time.deltaTime;
        TiempoDuracion = Math.Clamp(TiempoDuracion, 0, TiempoMAX);

        CirculoVida.fillAmount = TiempoDuracion / TiempoMAX;

        if (CirculoVida.fillAmount == 0)
        {
            IconEscudo.SetActive(false);
            CirculoVida.enabled = false;
        }
    }
    public void EscudoActivo()
    {
        TiempoDuracion = TiempoMAX;
        StartCoroutine(EngageShield());
        Debug.Log("Escudo está ACTIVO");
    }

    public IEnumerator EngageShield()
    {
        IconEscudo.SetActive(true);
        CirculoVida.enabled = true;
        PowerUpShield.OnActivarMesh.Invoke();
        PowerUpShield.OnActivarCollider.Invoke();
        PowerUpShield.OnAumentarEscala.Invoke();
        yield return new WaitForSeconds(TiempoDuracion);
        PowerUpShield.OnReducirEscala.Invoke();
        PowerUpShield.OnDesactivarMesh.Invoke();
        PowerUpShield.OnDesactivarCollider.Invoke();
        IconEscudo.SetActive(false);
       
    }

        
}
