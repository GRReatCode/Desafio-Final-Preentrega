using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activador_6 : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Button;
    [SerializeField] GameObject MissionC;
    [SerializeField] Animator MissionComplete;
    [SerializeField] AudioSource FxColonel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El player necesita una instrucción");
            this.GetComponent<BoxCollider>().enabled = false;
            Player.GetComponent<MovimientoInferior2>().enabled = false;
            StartCoroutine(MostrarDialogo());
        }
    }


    IEnumerator MostrarDialogo()
    {
        MissionC.SetActive(true);
        MissionComplete.SetTrigger("Complete");
        yield return new WaitForSeconds(2);
        FxColonel.Play();
        yield return new WaitForSeconds(2);
        Button.SetActive(true);
    }
}
