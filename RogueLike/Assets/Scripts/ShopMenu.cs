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
            GameManager.instance.DebitCoins(GameManager.instance.GetUpgradePrices()[0]);
            GameManager.instance.UpgradeHealth();
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
            GameManager.instance.DebitCoins(GameManager.instance.GetUpgradePrices()[1]);
            GameManager.instance.UpgradeDamage();
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
            GameManager.instance.DebitCoins(GameManager.instance.GetUpgradePrices()[2]);
            GameManager.instance.UpgradeDodge();
        }
        else
        {
            print("PAS ASSEZ DE COINS");
        }
    }
}
