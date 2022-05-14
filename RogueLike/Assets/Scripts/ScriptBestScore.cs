using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptBestScore : MonoBehaviour
{
    public Text BestScore;
    public GameManager gamemanager;
    
    public void Start()
    {
        BestScore = GetComponentInChildren<Text>();
        BestScore.text = "Best score : "+GameManager.instance.player.bestScore.ToString();
    }
}
