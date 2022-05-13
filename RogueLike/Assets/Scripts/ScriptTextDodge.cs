using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptTextDodge : MonoBehaviour
{
    public Text text;
    public GameManager manager;

    void Update()
    {
        text = GetComponentInChildren<Text>();
        text.text = GameManager.instance.GetUpgradePrices()[2].ToString();
    }
}
