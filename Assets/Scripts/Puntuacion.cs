using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuacion : MonoBehaviour
{
    [SerializeField] public int score;
    [SerializeField] TMP_Text TextoPuntuacion;




    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TextoPuntuacion.text = score.ToString();
    }
}
