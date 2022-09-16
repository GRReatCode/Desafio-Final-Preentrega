using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Activador_4 : MonoBehaviour
{

    [SerializeField] AudioSource FxEntradaRadio;
    [SerializeField] AudioSource FxNoiseRadio;
    [SerializeField] AudioSource FxSalidaRadio;
    [SerializeField] AudioSource[] AudioDialogo;
    [SerializeField] GameObject[] TextoDialogo;
    [SerializeField] GameObject ventanaTutorial;

    Animator anim;
    int contador;

    // Start is called before the first frame update
    void Start()
    {
        anim = ventanaTutorial.GetComponent<Animator>();
        this.GetComponent<BoxCollider>().enabled = true;
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            contador = contador +1;
        }

        if (Input.GetKeyDown(KeyCode.C)&& contador==2)
        {
            Debug.Log("El player necesita una instrucción");
            this.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(MostrarWellDone());
        }

    }


    IEnumerator MostrarWellDone()
    {
        FxEntradaRadio.Play();
        yield return new WaitForSeconds(1);

        // Inicia con sonido beep y noise
        FxEntradaRadio.Play();
        FxEntradaRadio.enabled = true;
        FxNoiseRadio.Play();
        FxNoiseRadio.enabled = true;
        // activa el trigger de la animacion para aparecer
        anim.SetTrigger("ampliacion");
        yield return new WaitForSeconds(1);
        // Inicia diálogo 3
        AudioDialogo[0].Play();
        AudioDialogo[0].enabled = true;
        TextoDialogo[0].SetActive(true);
        yield return new WaitForSeconds(6);
        FxNoiseRadio.Play();
        FxNoiseRadio.enabled = true;
        yield return new WaitForSeconds(1);
        FxSalidaRadio.Play();
        FxSalidaRadio.enabled = true;
        anim.SetTrigger("reduccion");
        yield return new WaitForSeconds(2);
        TextoDialogo[0].SetActive(false);
    }

}




