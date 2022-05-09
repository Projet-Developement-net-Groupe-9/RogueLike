using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;

    private SpriteRenderer spriteRenderer;
    private Sprite sprite;

    private List<Sprite> coinSprites;
    public int value;

    private void InitObjects()
    {
        gm = GameManager.instance;
        go = this.gameObject;
    }

    private void InitComponents()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void InitVars()
    {
        coinSprites = gm.coinSprites;
    }

    private void InitAll()
    {
        InitObjects();
        InitComponents();
        InitVars();
    }

    private void AssignValue()
    {
        value = (int)Random.Range(1f, 4f);
        if (value == 4)
            value = 5;
    }

    private void AssignSprite()
    {
        switch(value)
        {
            case 1:
                sprite = coinSprites[0];
                break;
            case 2:
                sprite = coinSprites[1];
                break;
            case 3:
                sprite = coinSprites[2];
                break;
            case 5:
                sprite = coinSprites[3];
                break;
        }
       
        spriteRenderer.sprite = sprite;
    }

    private void Start()
    {
        InitAll();
        AssignValue();
        AssignSprite();
    }
}
