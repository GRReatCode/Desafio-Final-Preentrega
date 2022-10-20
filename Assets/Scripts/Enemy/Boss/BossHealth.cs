using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BossHealth : MonoBehaviour
{
    public bool IsBurning { get => _IsBurning; set => _IsBurning = value; }


    [SerializeField]
    protected EnemyData enemyData;

    [SerializeField] float vidaActual;
    [SerializeField] public int vidaMax;
    [SerializeField] Image barraVida;
    [SerializeField] GameObject enemigo;
    [SerializeField] GameObject humo;
    [SerializeField] GameObject fuego;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject impactEffect;
    private bool _IsBurning;
    private Coroutine BurnCoroutine;

    public static event Action OnBossDead;

    private void Start()
    {
        vidaActual = vidaMax;
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
            BossHealth.OnBossDead?.Invoke();

        }
        else
        {
            explosion.SetActive(false);
        }

    }

    void OnCollisionEnter(Collision collision)

    {
        ContactPoint contact = collision.contacts[0];

        //Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));


        if (collision.gameObject.tag == "PlayerBullet")

        {
            Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));
            ApplyDamagePlayer();
        }

        if (collision.gameObject.tag == "PlayerPowerBullet")

        {
            Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));
            ApplyDamagePlayerPOWER();
        }
    }



    //------------ DA�O DEL PLAYER CON BALA NORMAL

    private void ApplyDamagePlayer()
    {
        vidaActual -= enemyData.playerdamage;

       
    }

    //------------ DA�O DEL PLAYER CON BALA POWER

    private void ApplyDamagePlayerPOWER()
    {
        vidaActual -= enemyData.playerPowerdamage;
    }

    void Derrotado()
    {
        explosion.SetActive(true);
        //this.GetComponent<Animator>().enabled = false;
        //this.GetComponent<FollowPlayer>().enabled = false;
        // this.GetComponent<Patrol>().enabled = false;
        // this.GetComponent<Enemy>().enabled = false;
        // enemigo.GetComponent<MovimientoInferior2>().enabled = false;        
        // enemigo.GetComponentInChildren<TurretControl>().enabled = false;
      //  Destroy(enemigo);
    }
    //------------ DA�O DEL PLAYER CON LANZALLAMAS

    public void StartBurning(int DamagePerSecond)
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
        int damagePerTick = Mathf.FloorToInt(minTimeToDamage) + 2;

        ApplyDamageLanzallamas(damagePerTick);
        while (IsBurning)
        {
            yield return wait;
            ApplyDamageLanzallamas(damagePerTick);
        }
    }
    public void StopBurning()
    {
        IsBurning = false;
        if (BurnCoroutine != null)
        {
            StopCoroutine(BurnCoroutine);
        }
    }
    public void ApplyDamageLanzallamas(float amount)
    {
        vidaActual -= Mathf.Abs(amount);
        if (vidaActual <= 0)
        {
            Derrotado();
        }
    }

}

