using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class LanzaLlamas : MonoBehaviour
{
    [SerializeField] private ParticleSystem ShootingSystem;
    [SerializeField] private ParticleSystem OnFireSystemPrefab;
    [SerializeField] private AttackRadius attackRadius;

    //[SerializeField] Image BarraFuego;
    [SerializeField] float CargaMaxima;
    [SerializeField] float RecargaFuel;
    [SerializeField] float ConsumoFuel;

    [Space]
    [SerializeField]
    private int BurningDPS = 5;
    [SerializeField]
    private float BurnDuration = 3f;

    private ObjectPool<ParticleSystem> OnFirePool;

    private Dictionary<Enemy, ParticleSystem> EnemyParticleSystems = new();

    private void Awake()
    {
        OnFirePool = new ObjectPool<ParticleSystem>(CreateOnFireSystem);
        attackRadius.OnEnemyEnter += StartDamagingEnemy;
        attackRadius.OnEnemyExit += StopDamagingEnemy;
        UILanzallamas.OnShoot += Shoot;
        UILanzallamas.OnStopShooting += StopShooting;


    }

    
    private void Update()
    {
        /*
        BarraFuego.fillAmount += RecargaFuel / CargaMaxima;

        if (Input.GetMouseButton(1))
        {
            Shoot();
            BarraFuego.fillAmount -= ConsumoFuel / CargaMaxima;
            if(BarraFuego.fillAmount == 0)
            {
                StopShooting();
            }

        }
        else
        {
            StopShooting();
        }
        */
    }
    private void Shoot()
    {
        ShootingSystem.gameObject.SetActive(true);
        attackRadius.gameObject.SetActive(true);
    }

    private void StopShooting()
    {
        attackRadius.gameObject.SetActive(false);
        ShootingSystem.gameObject.SetActive(false);
    }

    private ParticleSystem CreateOnFireSystem()
    {
        return Instantiate(OnFireSystemPrefab);
    }

    private void StartDamagingEnemy(Enemy Enemy)
    {
        if (Enemy.TryGetComponent<IBurnable>(out IBurnable burnable))
        {
            Debug.Log("fire");
            burnable.StartBurning(BurningDPS);
            ParticleSystem onFireSystem = OnFirePool.Get();
            onFireSystem.transform.SetParent(Enemy.transform, false);
            onFireSystem.transform.localPosition = Vector3.zero;
            ParticleSystem.MainModule main = onFireSystem.main;
            main.loop = true;
            EnemyParticleSystems.Add(Enemy, onFireSystem);
        }
    }

    private void HandleEnemyDeath(Enemy Enemy)
    {
        //Enemy.vidaActual.OnDeath -= HandleEnemyDeath;
        if (EnemyParticleSystems.ContainsKey(Enemy))
        {
            StartCoroutine(DelayedDisableBurn(Enemy, EnemyParticleSystems[Enemy], BurnDuration));
            EnemyParticleSystems.Remove(Enemy);
        }
    }

    private IEnumerator DelayedDisableBurn(Enemy Enemy, ParticleSystem Instance, float Duration)
    {
        ParticleSystem.MainModule main = Instance.main;
        main.loop = false;
        yield return new WaitForSeconds(Duration);
        Instance.gameObject.SetActive(false);
        if (Enemy.TryGetComponent<IBurnable>(out IBurnable burnable))
        {
            burnable.StopBurning();
        }
    }

    private void StopDamagingEnemy(Enemy Enemy)
    {
        //Enemy.vidaActual.OnDeath -= HandleEnemyDeath;
        if (EnemyParticleSystems.ContainsKey(Enemy))
        {
            StartCoroutine(DelayedDisableBurn(Enemy, EnemyParticleSystems[Enemy], BurnDuration));
            EnemyParticleSystems.Remove(Enemy);
        }
    }       
        
}
