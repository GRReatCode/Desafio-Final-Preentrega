using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager inst;
    private void Awake()
    {
        if (Manager.inst == null)
        {
            Manager.inst = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
