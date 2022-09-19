using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador_5 : MonoBehaviour
{

    [SerializeField] AudioSource FxEntradaRadio;
    [SerializeField] AudioSource FxNoiseRadio;
    [SerializeField] AudioSource FxSalidaRadio;
    [SerializeField] AudioSource[] AudioDialogo;
    [SerializeField] GameObject[] TextoDialogo;
    [SerializeField] GameObject ventanaTutorial;
    [SerializeField] GameObject lineas;
    [SerializeField] GameObject Player;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = ventanaTutorial.GetComponent<Animator>();
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
            lineas.GetComponent<Outline>().enabled = false;
            StartCoroutine(MostrarDialogo());
        }

    }


    IEnumerator MostrarDialogo()
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
        // Inicia Audio diálogo y muestra el texto en la ventana
        AudioDialogo[0].Play();
        AudioDialogo[0].enabled = true;
        TextoDialogo[0].SetActive(true);
        yield return new WaitForSeconds(6);
        // Inicia sonido de cierre
        FxSalidaRadio.Play();
        FxSalidaRadio.enabled = true;
        anim.SetTrigger("reduccion");
        yield return new WaitForSeconds(2);
        // Desactiva el texto de la ventana para que no se superponga con el siguiente texto que aparecerá
        TextoDialogo[0].SetActive(false);
        
    }

}