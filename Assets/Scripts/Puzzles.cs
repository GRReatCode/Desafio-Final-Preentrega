using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
    [SerializeField] public int puzzles;
    [SerializeField] public int puzzlesTotales = 2;
    [SerializeField] TMP_Text TextoPuzzles;
    




    // Start is called before the first frame update
    void Start()
    {
        puzzles = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzles == puzzlesTotales)
        {
            puzzles = puzzlesTotales;
        }


        TextoPuzzles.text = puzzles.ToString() +"/"+ puzzlesTotales;


    }


}

