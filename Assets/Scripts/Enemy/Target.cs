using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Target : MonoBehaviour // IDamageable, IBurnable
{
    [SerializeField]
    protected EnemyData enemyData;

    public bool IsBurning { get => _IsBurning; set => _IsBurning = value; }
    public float vidaActual;
    [SerializeField] public int vidaMax;    
    [SerializeField] Image barraVida;
    [SerializeField] GameObject enemigo;
    [SerializeField] GameObject humo;
    [SerializeField] GameObject fuego;
    [SerializeField] GameObject explosion;
    [SerializeField]
    private bool _IsBurning;
    private float _Health;
    private Coroutine BurnCoroutine;


    private void Start()
    {
        vidaActual = vidaMax;
        Bullet.OnGolpeAEnemigo += ApplyDamagePlayer;
        BulletPower.OnPowerEnEnemigo += ApplyDamagePlayerPOWER;
    }

    private void Update()
    {
        RevisarVida();
    }

    public void RevisarVida()
    {
        barraVida.fillAmount = vidaActual / vidaMax;


        if (vidaActual <= vidaMax / 5)
        {
            fuego.SetActive(true);
        }
        else
        {
            fuego.SetActive(false);
        }

        if (vidaActual <= vidaMax / 3)
        {
            humo.SetActive(true);
        }
        else
        {
            humo.SetActive(false);
        }

        if (vidaActual <= 0)
        {
            explosion.SetActive(true);
        }
        else
        {
            explosion.SetActive(false);
        }

    }


    //------------ DAÑO DEL PLAYER CON BALA NORMAL

    private void ApplyDamagePlayer()
    {
        vidaActual -= enemyData.playerdamage;
        if (vidaActual <= 0)
        {
            Derrotado();
        }
    }

    //------------ DAÑO DEL PLAYER CON BALA POWER

    private void ApplyDamagePlayerPOWER()
    {
        vidaActual -= enemyData.playerPowerdamage;
        if (vidaActual <= 0)
        {
            Derrotado();
        }
    }

    void Derrotado()
    {
        explosion.SetActive(true);
        //this.GetComponent<Animator>().enabled = false;
       // this.GetComponent<FollowPlayer>().enabled = false;
       // this.GetComponent<Patrol>().enabled = false;
       // this.GetComponent<Enemy>().enabled = false;
        //enemigo.GetComponent<MovimientoInferior2>().enabled = false;        
       // enemigo.GetComponentInChildren<TurretControl>().enabled = false;
        Destroy(enemigo);
    }

    /*public void StartBurning(int DamagePerSecond)
    {
        IsBurning = true;
        if (BurnCoroutine != null)
        {
            StopCoroutine(BurnCoroutine);
        }

        BurnCoroutine = StartCoroutine(Burn(DamagePerSecond));
    }
    private IEnumerator Burn(int DamagePerSecond)
    {

        Debug.Log("target");
        float minTimeToDamage = 1f / DamagePerSecond;
        WaitForSeconds wait = new WaitForSeconds(minTimeToDamage);
        FLOA damagePerTick = Mathf.FloorToInt(minTimeToDamage) + 2;

        ApplyDamage(damagePerTick);
        while (IsBurning)
        {
            yield return wait;
            ApplyDamage(damagePerTick);
        }
    }
    public void StopBurning()
    {
        IsBurning = false;
        if (BurnCoroutine != null)
        {
            StopCoroutine(BurnCoroutine);
        }
    }*/
}