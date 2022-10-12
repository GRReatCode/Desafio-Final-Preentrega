using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionInicial : MonoBehaviour
{
    [SerializeField] GameObject CamDolly;
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject CamPlayer;

    [SerializeField] GameObject Player;

   // [SerializeField] Animator Player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cinematica1());
    }

    IEnumerator Cinematica1()
    {
        CamDolly.SetActive(true);
        yield return new WaitForSeconds(15);
        CamPlayer.SetActive(true);
        yield return new WaitForSeconds(1);
       // Player.SetTrigger("SpawnPlayer");
        HUD.SetActive(true);
        Player.GetComponent<MovimientoInferior2>().enabled = true;
        Player.GetComponent<Shooter>().enabled = true;
    }
}
