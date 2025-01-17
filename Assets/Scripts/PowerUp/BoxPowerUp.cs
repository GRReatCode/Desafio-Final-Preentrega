using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPowerUp: MonoBehaviour
{

    //---------------------- PROPIEDADES SERIALIZADAS ----------------------

    [SerializeField] GameObject nuevoEstado;
    [SerializeField] GameObject explosion;      
    [SerializeField] GameObject generador;      
    [SerializeField] GameObject[] PowerUp;

    //---------------------- PROPIEDADES PRIVADAS ----------------------


    private void OnCollisionEnter(Collision collision)
    {
               
        /*if (collision.gameObject.tag == "PlayerBullet")
        {
            //Instantiate(nuevoEstado, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Instantiate(PowerUp[0], generador.transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag == "PlayerPowerBullet")
        {
            //Instantiate(nuevoEstado, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Instantiate(PowerUp[0], generador.transform.position, Quaternion.identity);
        }*/

        if (collision.gameObject.tag == "PlayerBullet")
        {
            int indexNumber = Random.Range(0, PowerUp.Length);

            //Instantiate(nuevoEstado, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Instantiate(PowerUp[indexNumber], generador.transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag == "PlayerPowerBullet")
        {
            int indexNumber = Random.Range(0, PowerUp.Length);

            //Instantiate(nuevoEstado, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Instantiate(PowerUp[indexNumber], generador.transform.position, Quaternion.identity);
        }
    }
}
