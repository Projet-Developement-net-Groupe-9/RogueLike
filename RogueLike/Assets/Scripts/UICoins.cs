using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoins : MonoBehaviour
{
    public Text NbCoins;

    void Update()
    {
        NbCoins = GetComponentInChildren<Text>();
        NbCoins.text = GameManager.instance.player.coins.ToString();
    }
}
