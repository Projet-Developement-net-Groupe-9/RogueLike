using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountScript : MonoBehaviour
{
    float currentTime = 0f;
    float endTime = 5f;

    public Text text;
    

    private void Start()
    {
        currentTime = endTime;
    }

    private void Update()
    {
        text = GetComponentInChildren<Text>();
        currentTime -= Time.deltaTime;
        text.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene("Spawn");
        }
           
    }
}
