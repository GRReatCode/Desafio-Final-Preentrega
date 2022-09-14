using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerWindow : MonoBehaviour
{
    //---------------- Propiedades serializadas
    
    
    [SerializeField] AudioSource FxEntradaRadio;
    [SerializeField] AudioSource FxNoiseRadio;
    [SerializeField] AudioSource FxSalidaRadio;
    [SerializeField] AudioSource[] AudioDialogo;
    [SerializeField] GameObject[] TextoDialogo;


    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(MostrarDialogo());
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(MostrarWellDone());
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
        // Inicia diálogo 1
        AudioDialogo[0].Play();
        AudioDialogo[0].enabled = true;
        yield return new WaitForSeconds(7);
        TextoDialogo[0].SetActive(false);
        FxNoiseRadio.Play();
        FxNoiseRadio.enabled = true;
        yield return new WaitForSeconds(1);
        TextoDialogo[1].SetActive(true);
        // Inicia diálogo 2
        AudioDialogo[1].Play();
        AudioDialogo[1].enabled = true;
        yield return new WaitForSeconds(14);

        FxSalidaRadio.Play();
        FxSalidaRadio.enabled = true;
        anim.SetTrigger("reduccion");
        yield return new WaitForSeconds(2);
        TextoDialogo[0].SetActive(false);
        TextoDialogo[1].SetActive(false);
        TextoDialogo[2].SetActive(true);

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
        AudioDialogo[2].Play();
        AudioDialogo[2].enabled = true;
        yield return new WaitForSeconds(6);
        FxNoiseRadio.Play();
        FxNoiseRadio.enabled = true;
        yield return new WaitForSeconds(1);
        FxSalidaRadio.Play();
        FxSalidaRadio.enabled = true;
        anim.SetTrigger("reduccion");
        yield return new WaitForSeconds(2);
        TextoDialogo[0].SetActive(true);
        TextoDialogo[1].SetActive(false);
        TextoDialogo[2].SetActive(false);

    }
}
