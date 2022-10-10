namespace ArionDigital
{
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

        //objetos para el powerUp bullet UI
        [SerializeField] public TMP_Text TextoBullets;
        [SerializeField] public int BalasPower = 0;
        [SerializeField] public int BalasTotales = 10;

        [SerializeField] AudioSource shootAudio;    // El sonido que hará al disparar

        //---------------------- PROPIEDADES PRIVADAS ----------------------

        private float shootRateTime = 0;

        private void Start()
        {
            PowerUpBullets.OnPowerBullets += SumarBalas;
        }

        private void Update()
        {

            TextoBullets.text = BalasPower + "/" + BalasTotales;

            if (Input.GetMouseButtonUp(0))
            {

                if (Time.time > shootRateTime)
                {
                    if (BalasPower <=0)
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

                    if (BalasPower > 0 && BalasPower <= BalasTotales)
                    {
                        BalasPower -= 1;
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
        }

        void SumarBalas()
        {
             BalasPower = BalasTotales;
        } 
    }
}