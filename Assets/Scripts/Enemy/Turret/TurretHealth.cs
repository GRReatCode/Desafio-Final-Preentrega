using System.Collections;
using System.Collections.Generic;
using ArionDigital;
using UnityEngine;
using UnityEngine.UI;

public class TurretHealth : MonoBehaviour, IDamageable, IBurnable
{
    public bool IsBurning { get => _IsBurning; set => _IsBurning = value; }
    

    [SerializeField]
    protected EnemyData enemyData;


    [SerializeField] float _vidaActual;
    [SerializeField] public int vidaMax;
    [SerializeField] Image barraVida;
    [SerializeField] GameObject enemigo;
    [SerializeField] GameObject humo;
    [SerializeField] GameObject fuego;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject impactEffect;
    private bool _IsBurning;
    private float _Health;
    private Coroutine BurnCoroutine;


    private void Start()
    {
        _vidaActual = vidaMax;
    }

    private void Update()
    {
        RevisarVida();
    }

    public void RevisarVida()
    {
        barraVida.fillAmount = _vidaActual / vidaMax;


        if (_vidaActual <= vidaMax / 5)
        {
            fuego.SetActive(true);
        }
        else
        {
            fuego.SetActive(false);
        }

        if (_vidaActual <= vidaMax / 3)
        {
            humo.SetActive(true);
        }
        else
        {
            humo.SetActive(false);
        }

        if (_vidaActual <= 0)
        {
            explosion.SetActive(true);
        }
        else
        {
            explosion.SetActive(false);
        }

    }

    void OnCollisionEnter(Collision collision)

    {
        ContactPoint contact = collision.contacts[0];

        Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));


        if (collision.gameObject.tag == "PlayerBullet")

        {
            ApplyDamagePlayer();
        }

        if (collision.gameObject.tag == "PlayerPowerBullet")

        {
            ApplyDamagePlayerPOWER();
        }
    }



    //------------ DAÑO DEL PLAYER CON BALA NORMAL

    private void ApplyDamagePlayer()
    {
        _vidaActual -= enemyData.playerdamage;

        if (_vidaActual <= 0)
        {
            Derrotado();
        }
    }

    //------------ DAÑO DEL PLAYER CON BALA POWER

    private void ApplyDamagePlayerPOWER()
    {
        _vidaActual -= enemyData.playerPowerdamage;

        if (_vidaActual <= 0)
        {
            Derrotado();
        }
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
        Destroy(enemigo);
    }
    //----DAÑO DEL LANZALLAMAS
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

        Debug.Log("burning");
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
        _vidaActual -= Mathf.Abs(amount);
        if (_vidaActual <= 0)
        {
            Derrotado();
        }
    }
}