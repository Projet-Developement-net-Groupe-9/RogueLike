using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountScript : MonoBehaviour
{
    float currentTime = 0f;

    public Text text;
    public TextMesh RoomCpt;
    

    private void Start()
    {
        currentTime = 3;
    }

    private void FixedUpdate()
    {
        text = GetComponentInChildren<Text>();

        currentTime -= Time.deltaTime;
        text.text = "Retour dans "+currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene("Spawn", LoadSceneMode.Single);
        }
           
    }
}
