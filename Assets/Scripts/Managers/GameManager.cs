using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameTerminado = false;
    public float restartDelay = 2f;
    // Start is called before the first frame update
    public void EndGame()
    {
        if (gameTerminado ==false)
        {
            gameTerminado = true;
            Invoke("Restart", restartDelay);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
