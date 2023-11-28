using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RSButton : MonoBehaviour
{
    public void OnRestart()
    {
        SceneManager.LoadScene(0);
    }

    public void OnStop()
    {
        Application.Quit();
    }
}
