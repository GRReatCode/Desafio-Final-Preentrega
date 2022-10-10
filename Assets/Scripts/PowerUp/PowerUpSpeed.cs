using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PowerUpSpeed : MonoBehaviour
{
    // Se debe cambiar el MAXSPEED cuando se cambiemos por inspector el valor de ShieldDuration
    public const float MAXSPEED = 20;
    public float speedDuration;
    public GameObject IconSpeed;
    [SerializeField] Image EnergySpeed;
    public GameObject Player;
    public GameObject effect;
    private WaitForSeconds shieldDelay;

    public static event Action OnSpeedUp;
    public static event Action OnNormalSpeed;


    // Start is called before the first frame update
    void Start()
    { 
        shieldDelay = new WaitForSeconds(speedDuration);
    }

    // Update is called once per frame
    void Update()
    {
        speedDuration -= Time.deltaTime;
        speedDuration = Math.Clamp(speedDuration, 0, MAXSPEED);
    }
    public void Speed_Up()
    {
        speedDuration = MAXSPEED;
        StartCoroutine(SpeedUp());
        Debug.Log("Speed Up");
    }

    public IEnumerator SpeedUp()
    {

        Player.GetComponent<Outline>().enabled = true;
        PowerUpSpeed.OnSpeedUp.Invoke();
       yield return new WaitForSeconds(MAXSPEED);
        PowerUpSpeed.OnNormalSpeed.Invoke();
        Player.GetComponent<Outline>().enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Speed")
        {

            Instantiate(effect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            EnergySpeed.enabled = true;
            IconSpeed.SetActive(true);
            Speed_Up();
        }
    }
}
