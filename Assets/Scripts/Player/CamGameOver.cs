using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamGameOver : MonoBehaviour
{

    [SerializeField] Transform Target;
    [SerializeField] int VelocidadMovimiento;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Target.Rotate(0,VelocidadMovimiento * Time.deltaTime, 0);
    }
}
