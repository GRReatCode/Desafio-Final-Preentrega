using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ---------------------

    enum Muerte { MuertePlayer }
    [SerializeField] Muerte muerte;

    //---------------------- PROPIEDADES PRIVADAS ---------------------

    void Start()
    {
        
    }

    void Update()
    {
        {
            switch (muerte)
            {
                case Muerte.MuertePlayer:
                    if (GameObject.FindWithTag("Player") == null)
                        Debug.Log("GAME OVER");
                    break;

                                
            }
        }
    }
}
