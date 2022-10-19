    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using System;

public class Shooter : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ----------------------

    [SerializeField] GameObject bullet;         // La bala que se instanciará
    [SerializeField] GameObject bulletPower;

    [SerializeField] GameObject bulletFalse;         // La bala que se instanciará
    [SerializeField] GameObject bulletPowerFalse;

    [SerializeField] Transform spawnDerecho;      // El objeto que los hará aparecer
    [SerializeField] Transform spawnIzquierdo;
    [SerializeField] float shootForce = 1500;   // La Fuerza disparo
    [SerializeField] float shootRate = 0.5f;    // La velocidad de repetición de disparo

    [SerializeField] AudioSource shootAudio;    // El sonido que hará al disparar

    // Evento que suma un disparo para FIRE - Accuracity
    public static event Action OnFired;

    //Evento que resta 1 bala al contador del PowerUp
    public static event Action OnBalaUsada;






    //---------------------- PROPIEDADES PRIVADAS ----------------------

    private float shootRateTime = 0;

    private void Awake()
    {
        PowerUpBullets.OnBulletPower += DisparoPower;
        PowerUpBullets.OnBulletNormal += DisparoNormal;
    }

    private void Start()
    {
       
    }

    private void Update()
    {
    }

    void DisparoPower()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Shooter.OnFired?.Invoke();
            if (Time.time > shootRateTime)
            {
                Shooter.OnBalaUsada?.Invoke();
                GameObject newBullet;
                newBullet = Instantiate(bulletPower, spawnDerecho.position, spawnDerecho.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnDerecho.forward * shootForce);

                newBullet = Instantiate(bulletPowerFalse, spawnIzquierdo.position, spawnIzquierdo.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnIzquierdo.forward * shootForce);

                shootRateTime = Time.time + shootRate;

                Destroy(newBullet, 3f);
            }
        }

    }

    void DisparoNormal()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Shooter.OnFired?.Invoke();
            if (Time.time > shootRateTime)
            {
                GameObject newBullet;
                shootAudio.Play();
                newBullet = Instantiate(bullet, spawnDerecho.position, spawnDerecho.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnDerecho.forward * shootForce);

                newBullet = Instantiate(bulletFalse, spawnIzquierdo.position, spawnIzquierdo.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnIzquierdo.forward * shootForce);

                shootRateTime = Time.time + shootRate;

                Destroy(newBullet, 3f);
            }



        }
    }
    private void OnDisable()
    {
        PowerUpBullets.OnBulletPower -= DisparoPower;
        PowerUpBullets.OnBulletNormal -= DisparoNormal;
    }
}