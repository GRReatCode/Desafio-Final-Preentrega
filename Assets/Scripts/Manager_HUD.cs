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
    [SerializeField] Animator UIFinal;
    //[SerializeField] GameObject MissionCompleteUI;
    [SerializeField] GameObject PuertasUI;

    private void Awake()
    {
        Health.OnPlayerDerrotado += DesactivarHUD;
        Health.OnPlayerDerrotado += ActivarGameOverUI;
        AnimacionInicial.OnActivarHUD += ActivarHUD;
        AnimacionInicialBoss.OnActivarHUD += ActivarHUD;
        BossHealth.OnBossDead += ActivarFinal;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameOverUI.SetActive(false);
        HUD.GetComponent<Canvas>().enabled = false;
        //HUD.SetActive(false);
        PausaUI.SetActive(false);
        PuertasUI.SetActive(true);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ActivarFinal()
    {
        UIFinal.SetTrigger("Final");
    }

    public void DesactivarHUD()
    {
        HUD.GetComponent<Canvas>().enabled = false;
       // HUD.SetActive(false);
    }

    public void ActivarHUD()
    {
        HUD.GetComponent<Canvas>().enabled = true;
        //HUD.SetActive(true);
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
        AnimacionInicialBoss.OnActivarHUD -= ActivarHUD;
        BossHealth.OnBossDead -= ActivarFinal;
    }
}
