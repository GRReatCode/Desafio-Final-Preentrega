using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepUi : MonoBehaviour
{
    public static KeepUi inst;
    private void Awake()
    {
        if (KeepUi.inst == null)
        {
            KeepUi.inst = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
