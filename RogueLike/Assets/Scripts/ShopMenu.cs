using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public Button button;

    public void BuyHealth()
    {
        if (GameManager.instance.player.coins >= GameManager.instance.GetUpgradePrices()[0])
        {
            GameManager.instance.player.health++;
            GameManager.instance.player.coins -= GameManager.instance.GetUpgradePrices()[0];
        }
        else
        {
            print("PAS ASSEZ DE COINS");
        }
    }

    public void BuyDamage()
    {
        if (GameManager.instance.player.coins >= GameManager.instance.GetUpgradePrices()[1])
        {
            GameManager.instance.player.damage++;
            GameManager.instance.player.coins -= GameManager.instance.GetUpgradePrices()[1];
        }
        else
        {
            print("PAS ASSEZ DE COINS");
        }
    }

    public void BuyDodge()
    {
        if (GameManager.instance.player.coins >= GameManager.instance.GetUpgradePrices()[2])
        {
            GameManager.instance.player.speed++;
            GameManager.instance.player.coins -= GameManager.instance.GetUpgradePrices()[2];
        }
        else
        {
            print("PAS ASSEZ DE COINS");
        }
    }
}
