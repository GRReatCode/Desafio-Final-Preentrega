using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Player;
    [SerializeField] Transform spawnPoint;

    private void Awake()
    {

        //Player = GameObject.Find("TankE");
        Instantiate(Player, spawnPoint.transform.position, spawnPoint.rotation);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
