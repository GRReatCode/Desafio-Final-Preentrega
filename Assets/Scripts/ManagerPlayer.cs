using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.Rendering.DebugUI;

public class ManagerPlayer : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Escudo;
    [SerializeField] Animator EscudoAnim;

    // GameObjects para estado de Game Over
    [SerializeField] GameObject humo;
    [SerializeField] GameObject fuego;
    [SerializeField] GameObject explosion;

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
        Escudo.transform.localScale = Vector3.zero;

        PowerUpSpeed.OnOutlineON += OutlineActivado;
        PowerUpSpeed.OnOutlineOFF += OutlineDesactivado;

        PowerUpSpeed.OnSpeedUp += AumentarVelocidad;
        PowerUpSpeed.OnNormalSpeed += VelocidadNormal;

        PowerUpShield.OnActivarMesh += ActivarMesh;
        PowerUpShield.OnActivarCollider += ActivarCollider;

        PowerUpShield.OnDesactivarMesh += DesactivarMesh;
        PowerUpShield.OnDesactivarCollider += DesactivarCollider;

        PowerUpShield.OnAumentarEscala += AumentarEscala;
        PowerUpShield.OnReducirEscala += ReducirEscala;

        Health.OnPlayerDerrotado += PlayerDerrotado;


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

    //---------------------- GAME OVER - PLAYER
    void PlayerDerrotado()
    {
        Player.GetComponent<MovimientoInferior2>().enabled = false;
        Player.GetComponent<Shooter>().enabled = false;
        Player.GetComponentInChildren<TurretControl>().enabled = false;
        humo.SetActive(true);
        fuego.SetActive(true);
        explosion.SetActive(true);
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

    //---------------------- ESCUDO - PLAYER

    void ActivarMesh()
    {
        Escudo.GetComponent<MeshRenderer>().enabled = true;
    }

    void ActivarCollider()
    {
        Escudo.GetComponent<Collider>().enabled = true;
    }

    void DesactivarMesh()
    {
        Escudo.GetComponent<MeshRenderer>().enabled = false;
    }

    void DesactivarCollider()
    {
        Escudo.GetComponent<Collider>().enabled = false;
    }

    void AumentarEscala()
    {
        EscudoAnim.SetTrigger("EscudoActivado");
    }

    void ReducirEscala()
    {
        EscudoAnim.SetTrigger("EscudoDesactivado");
    }
}
