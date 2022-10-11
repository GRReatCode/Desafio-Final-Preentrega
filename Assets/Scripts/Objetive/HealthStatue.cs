using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthStatue : MonoBehaviour
{
    [SerializeField] GameObject EnergyObjetive;
    [SerializeField] GameObject Estatua0;
    [SerializeField] GameObject Estatua1;
    [SerializeField] GameObject Estatua2;
    [SerializeField] GameObject explosionSmall;
    [SerializeField] GameObject explosionBig;
    [SerializeField] GameObject MissionComp;
    [SerializeField] GameObject Player;
    [SerializeField] Animator estatua2;
   // [SerializeField] Animator MissionC;
   // [SerializeField] Animator estrella1;
   // [SerializeField] Animator estrella2;
   // [SerializeField] Animator estrella3;
    [SerializeField] Image BarraVidaStatue;
    [SerializeField] int VidaMax;
    [SerializeField] int VidaActual;
    [SerializeField] int Damage;
    [SerializeField] int DamagePower;
    //[SerializeField] AudioSource[] audios;
    //[SerializeField] Acuracity acuracity;

    // Start is called before the first frame update
    void Start()
    {
        Puzzles.OnPuzzlesComplete += ActivarBarraVida;
        Bullet.OnGolpeAEstatua += QuitarVida;
        BulletPower.OnGolpeAEstatua += QuitarVidaPower;
        VidaActual = VidaMax;
         
    }

    // Update is called once per frame
    void Update()
    {

        RevisarVida();
    }

    void ActivarBarraVida()
    {
        EnergyObjetive.SetActive(true);
        this.GetComponent<BoxCollider>().enabled = true;
    }

    void RevisarVida()
    {
        if (VidaActual <= VidaMax / 3)
        {
            Estatua2.SetActive(true);
            Estatua1.SetActive(false);
            explosionBig.SetActive(true);
        }

        if (VidaActual <= VidaMax / 2)
        {
            Estatua1.SetActive(true);
            Estatua0.SetActive(false);
            explosionSmall.SetActive(true);
        }

        if (VidaActual <= 0 )
        {
            VidaActual = 0;
            
            this.GetComponent<BoxCollider>().enabled = false;
            Player.GetComponent<MovimientoInferior2>().enabled = false;
            Player.GetComponent<Shooter>().enabled = false;
            estatua2.SetTrigger("StatueDie");
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

}
