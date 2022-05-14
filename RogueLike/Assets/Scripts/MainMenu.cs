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
        SceneManager.LoadScene("Spawn", LoadSceneMode.Single);
    }

    public void NewGame()
    {
        begin = true;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Spawn", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        begin = false;
        Application.Quit();
    }

    private void Start()
    {
        
    }
}
