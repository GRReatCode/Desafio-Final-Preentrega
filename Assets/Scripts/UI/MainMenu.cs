using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Animator transitionAnimator;
    [SerializeField] private float tiempoEspera = 1.2f;

    private void Start()
    {
        transitionAnimator = GetComponent<Animator>();   
    }

    public void CargarScene(string nombreScene)
    {
        SceneManager.LoadScene(nombreScene);
    }



        public void Salir()
    {
        Application.Quit();
    }

    public IEnumerator SceneLoad(string nombreScene)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(tiempoEspera);
        SceneManager.LoadScene("nombreScene");
    }
}
