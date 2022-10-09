using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUpShield : MonoBehaviour
{
    // Se debe cambiar el MAXSHILD cuando se camnbie por inspector el valor de DurationShield
    public const float MAXSHIELD = 10;
    public float shieldDuration;
    public GameObject Shield;
    public GameObject effect;
    private WaitForSeconds shieldDelay;

    // Creo un evento que se dispará cuando comienza la corrutina y acciona la descarga de PowerUp
    public static event Action OnShieldActive;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
        shieldDelay = new WaitForSeconds(shieldDuration);
        //Shield.GetComponent<MeshRenderer>().enabled = false;
        //Shield.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        shieldDuration -= Time.deltaTime;
        shieldDuration = Math.Clamp(shieldDuration, 0, MAXSHIELD);
    }
    public void ShieldUp()
    {
        shieldDuration = MAXSHIELD;
        StartCoroutine(EngageShield());
        // se dispara el evento
        PowerUpShield.OnShieldActive.Invoke();
        Debug.Log("Shield Up");
    }

    public IEnumerator EngageShield()
    {
        Shield.GetComponent<MeshRenderer>().enabled = true;
        Shield.GetComponent<Collider>().enabled = true;

        float inAnimDuration = 0.5f;
        float outAnimDuration = 0.5f;

        while (inAnimDuration > 0f)
        {
            inAnimDuration -= Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(15, 15, 15), 0.1f);
            yield return null;
        }

        yield return shieldDelay;

        while (outAnimDuration > 0f)
        {
            outAnimDuration -= Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 0.1f);
            yield return null;
        }

        transform.localScale = Vector3.zero;
        //Shield.GetComponent<MeshRenderer>().enabled = false;
        Shield.GetComponent<Collider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            Instantiate(effect, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            ShieldUp();            
        }

        if (other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);            
        }

        //Debug.Log("Trigger");
    }
    /*
    private void OnCollisionEnter(Collider col)
    {
        if (col.gameObject.CompareTag("bullet"))
        {
            Destroy(col.gameObject);
            Debug.Log("bala destruida");
        }
    }
    */
}
