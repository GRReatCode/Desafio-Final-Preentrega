using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEstadoFinal: MonoBehaviour
{

    //---------------------- PROPIEDADES SERIALIZADAS ----------------------

    [SerializeField] GameObject nuevoEstado;
    [SerializeField] GameObject explosion;

    //---------------------- PROPIEDADES PRIVADAS ----------------------


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "PlayerBullet")
        {
            Instantiate(nuevoEstado, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "PlayerPowerBullet")
        {
            Instantiate(nuevoEstado, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "SpiderBullet")
        {
            Instantiate(nuevoEstado, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "TurretBullet")
        {
            Instantiate(nuevoEstado, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
