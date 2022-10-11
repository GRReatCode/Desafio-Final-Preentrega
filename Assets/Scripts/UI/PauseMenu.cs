using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool JuegoenPausa = false;

    public GameObject UIMenuPausa;

    // Update is called once per frame
    private void Start()
    {
        UIMenuPausa.SetActive(false);
        Time.timeScale = 1f;
        JuegoenPausa = false;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (JuegoenPausa)
            {
                Resume();
            }
            else
            {
                Pausa();
            }
        }
    }

    private void Pausa()
    {
        UIMenuPausa.SetActive(true);
        Time.timeScale = 0f;
        JuegoenPausa = true;
    }

    private void Resume()
    {
        UIMenuPausa.SetActive(false);
        Time.timeScale = 1f;
        JuegoenPausa = false;
    }
}
