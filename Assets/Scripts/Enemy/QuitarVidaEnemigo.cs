using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitarVidaEnemigo : MonoBehaviour
{
    [SerializeField] public VidaEnemigo vidaEnemigo;
    [SerializeField] float Damage = 20f;

    // Update is called once per frame
    void Update()
    {
        


    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "bullet") // Si la bala colisiona con el enemigo
        {
            vidaEnemigo.vidaActual -= Damage;

            if (vidaEnemigo.vidaActual <= 0)
            {
                Destroy(this.gameObject);
            }

        }
    }




    private void QuitarVida()
    {
        vidaEnemigo.vidaActual -= Damage;
    }
}
