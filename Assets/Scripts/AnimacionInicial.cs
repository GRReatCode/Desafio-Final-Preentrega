using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AnimacionInicial : MonoBehaviour
{
    


    [SerializeField] GameObject CamDolly;
   
    //[SerializeField] GameObject CamPlayer;

    [SerializeField] GameObject Player;

    public static event Action OnActivarHUD;
    public static event Action OnCamPlayer;

    // [SerializeField] Animator Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("TankE");
        StartCoroutine(Cinematica1());
        
    }

    IEnumerator Cinematica1()
    {
        CamDolly.SetActive(true);
        yield return new WaitForSeconds(15);
        AnimacionInicial.OnCamPlayer?.Invoke();
        yield return new WaitForSeconds(1);
        // Player.SetTrigger("SpawnPlayer");
        AnimacionInicial.OnActivarHUD?.Invoke();
        Player.GetComponent<MovimientoInferior2>().enabled = true;
        Player.GetComponent<Shooter>().enabled = true;
    }
}

