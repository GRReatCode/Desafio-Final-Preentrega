using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Animator anim;
    [SerializeField] private float tiempoEspera = 3f;
    [SerializeField] AudioSource FxPuerta;

    private void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    public void CargarScene(string nombreScene)
    {

        StartCoroutine(SceneLoad(nombreScene));
        //SceneManager.LoadScene(nombreScene);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



        public void Salir()
    {
        Application.Quit();
    }

    public IEnumerator SceneLoad(string nombreScene)
    {
        
        anim.SetTrigger("salidaScene");
        yield return new WaitForSeconds(0.5f);
        FxPuerta.Play();
        yield return new WaitForSeconds(tiempoEspera);
        SceneManager.LoadScene(nombreScene);
    }
}
