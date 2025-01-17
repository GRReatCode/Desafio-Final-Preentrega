using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Activador_2 : MonoBehaviour
{

    [SerializeField] AudioSource FxEntradaRadio;
    [SerializeField] AudioSource FxNoiseRadio;
    [SerializeField] AudioSource FxSalidaRadio;
    [SerializeField] AudioSource[] AudioDialogo;
    [SerializeField] GameObject[] TextoDialogo;
    [SerializeField] GameObject ventanaTutorial;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject puerta;

    Animator anim;
    Animator animPuerta;

    // Start is called before the first frame update
    void Start()
    {
        anim = ventanaTutorial.GetComponent<Animator>();
        animPuerta = puerta.GetComponent<Animator>();
        this.GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
        Player.GetComponent<MovimientoInferior2>().enabled = false;
        // Inicia con sonido beep y noise
        FxEntradaRadio.Play();
        FxEntradaRadio.enabled = true;
        FxNoiseRadio.Play();
        FxNoiseRadio.enabled = true;
        // activa el trigger de la animacion para aparecer
        anim.SetTrigger("ampliacion");
        yield return new WaitForSeconds(1);
        Camera.SetActive(true);
        animPuerta.SetTrigger("abriendoPuerta");
        // Inicia diálogo 3
        AudioDialogo[0].Play();
        AudioDialogo[0].enabled = true;
        yield return new WaitForSeconds(6);
        Camera.SetActive(false);
        FxNoiseRadio.Play();
        FxNoiseRadio.enabled = true;
        yield return new WaitForSeconds(1);
        FxSalidaRadio.Play();
        FxSalidaRadio.enabled = true;
        anim.SetTrigger("reduccion");
        Player.GetComponent<MovimientoInferior2>().enabled = true;
        yield return new WaitForSeconds(2);
        TextoDialogo[0].SetActive(false);
    }

}




