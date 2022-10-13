using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour, IDamageable, IBurnable
{
    
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

    public void ApplyDamage(float amount)
    {
        vidaActual -= Mathf.Abs(amount);
        if (vidaActual <= 0)
        {
            Die();
        }
    }

    public void ApplyDamagePower(float amount)
    {
        vidaActual -= Mathf.Abs(amount);
        if (vidaActual <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        explosion.SetActive(true);
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<FollowPlayer>().enabled = false;
        this.GetComponent<Patrol>().enabled = false;
        this.GetComponent<Enemy>().enabled = false;
        // enemigo.GetComponent<MovimientoInferior2>().enabled = false;        
        // enemigo.GetComponentInChildren<TurretControl>().enabled = false;
        //Destroy(gameObject);
    }
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
    }
}