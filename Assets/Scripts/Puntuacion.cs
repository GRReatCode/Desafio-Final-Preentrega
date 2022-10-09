using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuacion : MonoBehaviour
{
    [SerializeField] public int score=0;
    [SerializeField] TMP_Text TextoPuntuacion;




    // Start is called before the first frame update
    void Start()
    {
        Bullet.OnGolpeACaja += Sumar10;
        Bullet.OnGolpeABalas += Sumar50;
        Bullet.OnGolpeAEnemigo += Sumar100;
        Bullet.OnGolpeAEstatua += Sumar200;

    }

    // Update is called once per frame
    void Update()
    {
        TextoPuntuacion.text = score.ToString();
    }

    void Sumar10()
    {
        score += 10;
    }

    void Sumar50()
    {
        score += 50;
    }
    void Sumar100()
    {
        score += 100;
    }

    void Sumar200()
    {
        score += 200;
    }
}
