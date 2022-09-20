using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image PlayerHealthBar;
    //public float CurrentHealth;
    //public float MaxHealth = 100f;
    Health Player;

    private void Start()
    {
        PlayerHealthBar = GetComponent<Image>();
        Player = FindObjectOfType<Health>();
    }

    private void Update()
    {
        //CurrentHealth = Player.health;
        PlayerHealthBar.fillAmount = Player.health;
    }
}
