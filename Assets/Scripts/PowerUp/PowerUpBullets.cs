using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PowerUpBullets : MonoBehaviour
{
    public GameObject effect;

    public static event Action OnPowerBullets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Power")
        {

            Instantiate(effect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            PowerUpBullets.OnPowerBullets.Invoke();
        }
    }
}
