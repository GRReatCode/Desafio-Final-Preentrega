using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaRadar : MonoBehaviour
{
    [SerializeField] public bool activo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activo)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            StartCoroutine(tiempo());
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    IEnumerator tiempo()
    {
        yield return new WaitForSeconds(2);
        activo = false;
    }

}
