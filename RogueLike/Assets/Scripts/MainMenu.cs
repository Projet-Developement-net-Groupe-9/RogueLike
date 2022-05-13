using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool begin;

    public void PlayGame()
    {
        begin = true;
        SceneManager.LoadScene("Spawn");
    }

    public void ExitGame()
    {
        begin = false;
        Application.Quit();
    }
}