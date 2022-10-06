using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public GameObject effect;
    public float curar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthUp(other);
            Debug.Log("contacto player");
        }
    }

    void HealthUp(Collider player)
    {
        Instantiate(effect, transform.position, transform.rotation);
        Health stats = player.GetComponent<Health>();
        stats.vidaActual += curar;
        Debug.Log("Health");
        Destroy(gameObject);
    }
}
