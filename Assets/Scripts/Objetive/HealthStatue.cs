using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthStatue : MonoBehaviour
{
    //------------ Animación y camaras
    [SerializeField] Animator estatua2;
    [SerializeField] GameObject CamFinal;

    //------------ Variables de Barra de vida
    [SerializeField] GameObject EnergyObjetive;
    [SerializeField] Image BarraVidaStatue;
    [SerializeField] float VidaMax;
    [SerializeField] float VidaActual;
    [SerializeField] float Damage;
    [SerializeField] float DamagePower;

    //------------ Modelos y Fx
    [SerializeField] GameObject Estatua0;
    [SerializeField] GameObject Estatua1;
    [SerializeField] GameObject Estatua2;
    [SerializeField] GameObject explosionSmall;
    [SerializeField] GameObject explosionBig;
    [SerializeField] GameObject Player;

    //------------ Evento Derrota Enemigo
    public static event Action OnDerrotaEnemigo;

    private void Awake()
    {
        Puzzles.OnPuzzlesComplete += ActivarBarraVida;
        Bullet.OnGolpeAEstatua += QuitarVida;
        BulletPower.OnGolpeAEstatua += QuitarVidaPower;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
        BarraVidaStatue.fillAmount = VidaActual / VidaMax;
    }

    void ActivarBarraVida()
    {
        EnergyObjetive.SetActive(true);
        this.GetComponent<BoxCollider>().enabled = true;
    }

    void RevisarVida()
    {
        if (VidaActual <= VidaMax / 4)
        {
            Estatua0.SetActive(false);
            Estatua1.SetActive(false);
            Estatua2.SetActive(true);
            explosionBig.SetActive(true);
        }

        if (VidaActual > VidaMax / 4 && VidaActual <= VidaMax / 2)
        {
            
            Estatua0.SetActive(false);
            Estatua1.SetActive(true);
            Estatua2.SetActive(false);
            explosionSmall.SetActive(true);
        }

        if (VidaActual <= 0 )
        {
            VidaActual = 0;
            Estatua0.SetActive(false);
            Estatua1.SetActive(false);
            Estatua2.SetActive(true);

            StartCoroutine(EstatuaMuerta());
        }
    }

    
    void QuitarVida()
    {
        VidaActual -= Damage;
    }

    void QuitarVidaPower()
    {
        VidaActual -= DamagePower;
    }

    IEnumerator EstatuaMuerta()
    {
        // Desactivo el collider para que no se pueda seguir quitando vida
        this.GetComponent<BoxCollider>().enabled = false;
        //Anulo movimientos y disparos del player
        Player.GetComponent<MovimientoInferior2>().enabled = false;
        Player.GetComponent<Shooter>().enabled = false;
        // activo cámara fija
        CamFinal.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        // inicio animación de derrota enemiga
        estatua2.SetTrigger("StatueDie");
        yield return new WaitForSeconds(4);
        // Invoco el evento derrota Enemigo
        HealthStatue.OnDerrotaEnemigo?.Invoke();
        
    }

    private void OnDisable()
    {
        Puzzles.OnPuzzlesComplete -= ActivarBarraVida;
        Bullet.OnGolpeAEstatua -= QuitarVida;
        BulletPower.OnGolpeAEstatua -= QuitarVidaPower;
    }
}
