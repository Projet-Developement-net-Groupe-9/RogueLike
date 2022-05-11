using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;

    public EnemyMove enemyMove;

    public int health;
    public float speed;
    public float agroRange;

    private void InitObjects()
    {
        gm = GameManager.instance;
        go = gameObject;
    }

    private void InitComponents()
    {
        enemyMove = GetComponent<EnemyMove>();
    }

    private void InitVars()
    {
        health = 1;
        speed = 1f;
        agroRange = 0.5f;
    }

    private void InitAll()
    {
        InitObjects();
        InitComponents();
        InitVars();
    }

    private void Start()
    {
        InitAll();
        enemyMove.EnemyMoveStart();
    }

    private void Update()
    {
        enemyMove.EnemyMoveUpdate();       
    }

    private void FixedUpdate()
    {
        enemyMove.EnemyMoveFixedUpdate();
    }
}
