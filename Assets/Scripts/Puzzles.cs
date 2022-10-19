using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class Puzzles : MonoBehaviour
{
    [SerializeField] public int puzzles=0;
    [SerializeField] public int puzzlesTotales = 2;
    [SerializeField] public TMP_Text TextoPuzzles;


    public static event Action OnPuzzlesComplete;

    private void Awake()
    {
        Activador1.OnPuzzle1Active += SumarPuzzle;
        Activador2.OnPuzzle2Active += SumarPuzzle;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextoPuzzles.text = puzzles +"/"+ puzzlesTotales;

        if(puzzles == puzzlesTotales)
        {
            Puzzles.OnPuzzlesComplete.Invoke();
        }
    }

    private void SumarPuzzle()
    {
        
        if (puzzles < puzzlesTotales)
        {
            puzzles++;
            Debug.Log("Suma un Puzzle Completado");
            //OnPuzzleComplete.Invoke();
        }
        

        
    }

    private void OnDisable()
    {
        Activador1.OnPuzzle1Active -= SumarPuzzle;
        Activador2.OnPuzzle2Active -= SumarPuzzle;
    }

}

