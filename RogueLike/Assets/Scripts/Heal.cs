using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;

    public int value;

    private void InitObjects()
    {
        gm = GameManager.instance;
        go = gameObject;
    }

    private void InitVars()
    {
        value = 1;
    }

    private void InitAll()
    {
        InitObjects();
        InitVars();
    }

    private void Start()
    {
        InitAll();
    }
}
