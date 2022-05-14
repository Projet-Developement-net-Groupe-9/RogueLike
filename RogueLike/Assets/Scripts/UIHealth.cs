using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public Text NbHP;

    void Update()
    {
        NbHP = GetComponentInChildren<Text>();
        NbHP.text = GameManager.instance.player.health.ToString();
    }
}
