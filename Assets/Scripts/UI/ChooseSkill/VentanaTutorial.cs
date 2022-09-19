using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VentanaTutorial : MonoBehaviour
{
    Animator anim;
    [SerializeField] AudioSource FxRadioNoise;
    [SerializeField] AudioSource FxRadioEntrada;
    [SerializeField] AudioSource AudioCoronel;

    private void Start()
    {
        anim = GetComponent<Animator>();

    }

    public void LanzarVentana()
    {

        StartCoroutine(apertura());
        //SceneManager.LoadScene(nombreScene);
    }

    public IEnumerator apertura()
    {
        // se abre la ventana
        anim.SetTrigger("aperturaVentana");
        // se reproducen los audios de Radio
        FxRadioEntrada.Play();
        yield return new WaitForSeconds(1);
        FxRadioNoise.Play();
        yield return new WaitForSeconds(1);
        // se reproduce el audio del Coronel
        AudioCoronel.Play();
        
    }
}
