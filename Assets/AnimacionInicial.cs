using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionInicial : MonoBehaviour
{
    [SerializeField] GameObject CamDolly;
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject CamPlayer;
    [SerializeField] Animator Player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cinematica1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Cinematica1()
    {
        CamDolly.SetActive(true);
        yield return new WaitForSeconds(15);
        CamPlayer.SetActive(true);
        yield return new WaitForSeconds(1);
        Player.SetTrigger("SpawnPlayer");
        HUD.SetActive(true);
    }
}
