using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptTextHealth : MonoBehaviour
{
    public Text text;
    public Button button;
    public GameManager manager;

    void Update()
    {
        text = GetComponentInChildren<Text>();
        text.text = GameManager.instance.GetUpgradePrices()[0].ToString();
    }
}
