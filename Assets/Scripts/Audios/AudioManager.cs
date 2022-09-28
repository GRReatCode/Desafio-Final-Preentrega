using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource[] ListaDeAudios;
    
    void Update()
    {
        Activador1.OnPuzzle1Active += PuzzleComplete1;
        
    }

    private void PuzzleComplete1()
    {
        ListaDeAudios[0].Play();
        ListaDeAudios[0].enabled = true;
    }
}
