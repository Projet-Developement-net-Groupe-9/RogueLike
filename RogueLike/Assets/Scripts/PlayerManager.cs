using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameManager gm;

    public int health;
    public int coins;
    public float speed;
    public int maxHealth;

    public void UpdateGM()
    {
        if (gm != null)
        {
            gm.health = health;
            gm.coins = coins;
            gm.speed = speed;
            gm.maxHealth = maxHealth;
        }
    }

    private void InitVar()
    {
        gm = GameManager.instance;

        if (gm.health == 0)
        {
            health = 5;
            coins = 0;
            speed = 1f;
            maxHealth = health;
        }
        else
        {
            health = gm.health;
            coins = gm.coins;
            speed = gm.speed;
            maxHealth = gm.maxHealth;
        }
    }

    private void Start()
    {
        InitVar();
        //gm.player = this;
    }
}
