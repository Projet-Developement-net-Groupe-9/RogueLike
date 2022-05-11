using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;

    public Enemy enemy;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody;

    public bool agro;
    public int collMult;
    public float speed;
    public Vector2 moveDir;

    private void InitObjects()
    {
        gm = GameManager.instance;
        go = gameObject;
    }

    private void InitComponents()
    {
        enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void InitVars()
    {
        collMult = 1; 
        agro = false;
    }

    private void Agro()
    {
        if (Vector3.Distance(transform.position, gm.player.transform.position) <= enemy.agroRange)
            agro = true;
    }

    private void HandleMoveDir()
    {
        moveDir = (gm.player.rigidBody.position - rigidBody.position);
    }

    private void HandleSpeed()
    {
        float speedMult;

        if (moveDir.x == 0 || moveDir.y == 0)
            speedMult = 1f;
        else
            speedMult = 0.71f;

        speed = gm.velocity * enemy.speed * speedMult * collMult;
        print(speed);
    }

    private void Move()
    {
        if (moveDir.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        else if (moveDir.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (agro)
        {
            rigidBody.MovePosition(rigidBody.position + (moveDir * Time.fixedDeltaTime * speed));
        }
    }

    private void InitAll()
    {
        InitObjects();
        InitComponents();
        InitVars();
    }

    public void EnemyMoveStart()
    {
        InitAll();
    }

    public void EnemyMoveUpdate()
    {
        if (!agro)
            Agro();
        HandleSpeed();
    }

    public void EnemyMoveFixedUpdate()
    {
        HandleMoveDir();
        Move();
    }
}
