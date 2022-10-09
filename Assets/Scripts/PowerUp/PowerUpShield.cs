using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PowerUpShield : MonoBehaviour
{
    // Se debe cambiar el MAXSHILD cuando se cambiemos por inspector el valor de ShieldDuration
    public const float MAXSHIELD = 20;
    public float shieldDuration;
    public GameObject IconEscudo;
    [SerializeField] Image EnergyEscudo;
    public GameObject Shield;
    public GameObject effect;
    private WaitForSeconds shieldDelay;

    // Start is called before the first frame update
    void Start()
    {
        Shield.transform.localScale = Vector3.zero;
        shieldDelay = new WaitForSeconds(shieldDuration);
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
            Shield.transform.localScale = Vector3.Lerp(Shield.transform.localScale, new Vector3(15, 15, 15), 0.1f);
            yield return null;
        }

        yield return shieldDelay;

        while (outAnimDuration > 0f)
        {
            outAnimDuration -= Time.deltaTime;
            Shield.transform.localScale = Vector3.Lerp(Shield.transform.localScale, Vector3.zero, 0.1f);
            yield return null;
        }

        Shield.transform.localScale = Vector3.zero;
        //Shield.GetComponent<MeshRenderer>().enabled = false;
        Shield.GetComponent<Collider>().enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Shield")
        {

            Instantiate(effect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            EnergyEscudo.enabled = true;
            IconEscudo.SetActive(true);
            ShieldUp();
        }
    }
}
