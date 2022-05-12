using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;
    public GameObject healPrefab;

    public EnemyMove enemyMove;
    public EnemyDetect enemyDetect;
    public EnemyAttack enemyAttack;

    public int health;
    public int damage;
    public float speed;
    public float agroRange;
    public int rewardId;

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

    private void drawReward()
    {
        // 0 -> Pas de récompense
        // 1 -> Heal
        // 2 -> Coin
        rewardId = (int)Random.Range(0f, 3f);
    }

    private void checkHealth()
    {
        if (health <= 0)
        {
            if (rewardId == 1)
            {
                Instantiate(gm.coinPrefab, transform.position, Quaternion.identity);
            }
            else if (rewardId == 2)
            {
                Instantiate(gm.healPrefab, transform.position, Quaternion.identity);
            }
            
            Destroy(go);
        }
    }

    private void Start()
    {
        InitAll();
        drawReward();
        enemyMove.EnemyMoveStart();
        enemyDetect.EnemyDetectStart();
        enemyAttack.EnemyAttackStart();
    }

    private void Update()
    {
        enemyMove.EnemyMoveUpdate();
        checkHealth();
    }

    private void FixedUpdate()
    {
        enemyMove.EnemyMoveFixedUpdate();
    }
}
