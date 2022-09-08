using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas : MonoBehaviour
{
    [SerializeField] public float Damage = 20f;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "caja") // Si la bala colisiona con una caja, se destruye
        {
            Debug.Log("La bala colisionó con una caja");
            Destroy(this.gameObject);

        }

        if (collision.gameObject.tag == "bullet") // Si la bala colisiona con otra bala, se destruye
        {
            Debug.Log("La bala colisionó con una caja");
            Destroy(this.gameObject);
        }

<<<<<<< Updated upstream
        if (collision.gameObject.tag == "Enemy") // Si la bala colisiona con un enemigo, se destruye
        {
            Debug.Log("La bala colisionó con un enemigo");
=======
        if (collision.gameObject.tag == "Enemy") // Si la bala colisiona con otra bala, se destruye
        {
            Debug.Log("La bala colisionó con una caja");
>>>>>>> Stashed changes
            Destroy(this.gameObject);
        }
    }

    

}
