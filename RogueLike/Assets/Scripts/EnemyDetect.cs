using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;

    public Enemy enemy;
    public Animator animator;

    private float coolDown;
    private float lastAttack;

    private void InitObjects()
    {
        gm = GameManager.instance;
        go = gameObject;
    }

    private void InitComponents()
    {
        enemy = GetComponentInParent<Enemy>();
        animator = GetComponentInParent<Animator>();
    }

    private void InitVars()
    {
        coolDown = 0.7f;
        lastAttack = 0.0f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collGo = collision.gameObject;

        if (collGo.tag == "player")
        {
            print("stay");

            Player player = collGo.GetComponent<Player>();

            if (Time.time - lastAttack > coolDown)
            {
                lastAttack = Time.time;
                print("attack");
                animator.Play("EnemyAttack", 0, 0.0f);
            }
        }
    }

    private void InitAll()
    {
        InitObjects();
        InitComponents();
        InitVars();
    }

    public void EnemyDetectStart()
    {
        InitAll();
    }
}
