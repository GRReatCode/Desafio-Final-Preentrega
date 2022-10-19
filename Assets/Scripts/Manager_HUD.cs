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

    private void Awake()
    {
        Health.OnPlayerDerrotado += DesactivarHUD;
        Health.OnPlayerDerrotado += ActivarGameOverUI;
        AnimacionInicial.OnActivarHUD += ActivarHUD;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameOverUI.SetActive(false);
        HUD.SetActive(false);
        PausaUI.SetActive(false);
        PuertasUI.SetActive(true);

        
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

    private void OnDisable()
    {
        Health.OnPlayerDerrotado -= DesactivarHUD;
        Health.OnPlayerDerrotado -= ActivarGameOverUI;
        AnimacionInicial.OnActivarHUD -= ActivarHUD;
    }
}
