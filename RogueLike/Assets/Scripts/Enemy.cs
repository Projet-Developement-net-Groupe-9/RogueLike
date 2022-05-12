using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;

    public EnemyMove enemyMove;
    public EnemyDetect enemyDetect;
    public EnemyAttack enemyAttack;

    public int health;
    public int damage;
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
        enemyDetect = GetComponentInChildren<EnemyDetect>();
        enemyAttack = GetComponentInChildren<EnemyAttack>();
    }

    private void InitVars()
    {
        health = 1;
        damage = 1;
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
        enemyDetect.EnemyDetectStart();
        enemyAttack.EnemyAttackStart();
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
