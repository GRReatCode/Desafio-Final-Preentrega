using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "caja") // Si la bala colisiona con una caja, se destruye
        {
            Debug.Log("La bala colisionó con una caja");
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "SpiderBullet") // Si la bala colisiona con otra bala, se destruye
        {
            Debug.Log("La bala colisionó con una caja");
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "TurretBullet") // Si la bala colisiona con otra bala, se destruye
        {
            Debug.Log("La bala colisionó con una caja");
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BoosBullet") // Si la bala colisiona con otra bala, se destruye
        {
            Debug.Log("La bala colisionó con una caja");
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy") // Si la bala colisiona con un enemigo, se destruye
        {
            Debug.Log("La bala colisionó con un enemigo");
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PlayerBullet") // Si la bala colisiona con un enemigo, se destruye
        {
            Debug.Log("La bala colisionó con un enemigo");
            Destroy(gameObject);
        }

    }

    

}
