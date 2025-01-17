using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] AudioSource explosionAudio;
    public float delay = 3f;
    public float radio = 5f;
    public GameObject explosionEffect;
    public float damage = 25f;
    bool haExplotado = false;
    float countdown;
    public static event Action OnGrenadeHit;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !haExplotado)
        {
            Explode();
            haExplotado = true;
        }
    }

    private void Explode()
    {

        
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, radio);

        foreach (Collider col in hitcolliders)
        {
            if (col.gameObject.tag == "Player")
            {
                Debug.Log("Player en Radio");
                Grenade.OnGrenadeHit.Invoke();
               
                // Health target = col.transform.gameObject.GetComponent<Health>();
               // target.ApplyDamage(damage);                
            }            

        }
        explosionAudio.Play();
       
        Destroy(gameObject, 0.6f);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;     
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
