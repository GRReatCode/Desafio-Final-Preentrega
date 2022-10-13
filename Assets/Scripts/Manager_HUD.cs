using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Manager_HUD : MonoBehaviour
{
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject PausaUI;
    //[SerializeField] GameObject MissionCompleteUI;
    [SerializeField] GameObject PuertasUI;


    // Start is called before the first frame update
    void Start()
    {
        GameOverUI.SetActive(false);
        HUD.SetActive(false);
        PausaUI.SetActive(false);
        PuertasUI.SetActive(true);

        Health.OnPlayerDie += DesactivarHUD;
        Health.OnPlayerDie += ActivarGameOverUI;
        AnimacionInicial.OnActivarHUD += ActivarHUD;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DesactivarHUD()
    {
        HUD.SetActive(false);
    }

    public void ActivarHUD()
    {
        HUD.SetActive(true);
        PausaUI.SetActive(true);
    }

    public void ActivarGameOverUI()
    {
        GameOverUI.SetActive(true);
    }
}
