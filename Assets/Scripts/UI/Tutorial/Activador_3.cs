using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador_3 : MonoBehaviour
{

    [SerializeField] AudioSource FxEntradaRadio;
    [SerializeField] AudioSource FxNoiseRadio;
    [SerializeField] AudioSource FxSalidaRadio;
    [SerializeField] AudioSource[] AudioDialogo;
    [SerializeField] GameObject[] TextoDialogo;
    [SerializeField] GameObject ventanaTutorial;
    [SerializeField] GameObject lineas;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject ManagerCamera;

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
        Player.GetComponent<MovimientoInferior2>().enabled = false;
        Player.GetComponent<Activador_4>().enabled = false;
        // Inicia diálogo 1
        AudioDialogo[0].Play();
        AudioDialogo[0].enabled = true;
        TextoDialogo[0].SetActive(true);
        yield return new WaitForSeconds(7);
        TextoDialogo[0].SetActive(false);
        TextoDialogo[1].SetActive(true);
        yield return new WaitForSeconds(11);
        Player.GetComponent<MovimientoInferior2>().enabled = true;
        Player.GetComponent<Activador_4>().enabled = true;
        ManagerCamera.GetComponent<CameraManager>().enabled = true;
        FxSalidaRadio.Play();
        FxSalidaRadio.enabled = true;
        anim.SetTrigger("reduccion");
        yield return new WaitForSeconds(2);
        TextoDialogo[0].SetActive(false);
        TextoDialogo[1].SetActive(false);
    }

}