using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuacion : MonoBehaviour
{
    [SerializeField] public int score=0;
    [SerializeField] TMP_Text TextoPuntuacion;


    private void Awake()
    {
        Bullet.OnGolpeACaja += Sumar10;
        BulletPower.OnGolpeACaja += Sumar50;
        Bullet.OnGolpeABalas += Sumar50;
        BulletPower.OnGolpeABalas += Sumar100;
        Bullet.OnGolpeAEnemigo += Sumar100;
        BulletPower.OnPowerEnEnemigo += Sumar200;
        Bullet.OnGolpeAEstatua += Sumar200;
        BulletPower.OnGolpeAEstatua += Sumar400;
    }

    // Start is called before the first frame update
    void Start()
    {
        
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

    void Sumar400()
    {
        score += 400;
    }

    private void OnDisable()
    {
        Bullet.OnGolpeACaja -= Sumar10;
        BulletPower.OnGolpeACaja -= Sumar50;
        Bullet.OnGolpeABalas -= Sumar50;
        BulletPower.OnGolpeABalas -= Sumar100;
        Bullet.OnGolpeAEnemigo -= Sumar100;
        BulletPower.OnPowerEnEnemigo -= Sumar200;
        Bullet.OnGolpeAEstatua -= Sumar200;
        BulletPower.OnGolpeAEstatua -= Sumar400;
    }
}
