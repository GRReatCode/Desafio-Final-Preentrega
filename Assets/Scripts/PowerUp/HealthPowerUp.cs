using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public GameObject effect;
    public float curar;

    public static event Action OnHealth;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HealthUp();
            Debug.Log("contacto con player");
        }
    }

    
        
 

    void HealthUp()
    {
        Instantiate(effect, transform.position, transform.rotation);
        HealthPowerUp.OnHealth.Invoke();
        Debug.Log("Health");
        Destroy(gameObject);
    }
}
