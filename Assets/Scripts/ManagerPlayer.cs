using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManagerPlayer : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] GameObject Player;

    // creo los 4 eventos uno para cada Power Up
    public static event Action OnPowerUpSpeed;
    public static event Action OnPowerUpHealth;
    public static event Action OnPowerUpShield;
    public static event Action OnPowerUpBullet;

    // creo los eventos para subir y normalizar la velocidad del player
    public static event Action OnFastSpeed;
    public static event Action OnNormalSpeed;

    private void Start()
    {
        PowerUpSpeed.OnOutlineON += OutlineActivado;
        PowerUpSpeed.OnOutlineOFF += OutlineDesactivado;
        PowerUpSpeed.OnSpeedUp += AumentarVelocidad;
        PowerUpSpeed.OnNormalSpeed += VelocidadNormal;
       
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Speed")
        {
            Instantiate(effect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);

            ManagerPlayer.OnPowerUpSpeed.Invoke();
        }

        if (collision.gameObject.tag == "Health")
        {
            Instantiate(effect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);

            ManagerPlayer.OnPowerUpHealth.Invoke();
        }

        if (collision.gameObject.tag == "Shield")
        {
            Instantiate(effect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);

            ManagerPlayer.OnPowerUpShield.Invoke();
        }

        if (collision.gameObject.tag == "Power")
        {
            Instantiate(effect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);

            ManagerPlayer.OnPowerUpBullet.Invoke();
        }
    }

    //---------------------- OUTLINE - PLAYER
    void OutlineActivado()
    {
        Player.GetComponent<Outline>().enabled = true;
    }

    void OutlineDesactivado()
    {
        Player.GetComponent<Outline>().enabled = false;
        Debug.Log("PowerUp SPEED DESACTIVADO");
    }

    //---------------------- MOVIMIENTO INFERIOR 2 - PLAYER
    void AumentarVelocidad()
    {
        ManagerPlayer.OnFastSpeed.Invoke();
    }

    void VelocidadNormal()
    {
        ManagerPlayer.OnNormalSpeed.Invoke();
    }

}
