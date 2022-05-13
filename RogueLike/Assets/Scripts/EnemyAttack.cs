using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;

    public Enemy enemy;

    private void InitObjects()
    {
        gm = GameManager.instance;
        go = gameObject;
    }

    private void InitComponents()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void InitAll()
    {
        InitObjects();
        InitComponents();
    }

    public void EnemyAttackStart()
    {
        InitAll();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collGo = collision.gameObject;

        if (collGo.tag == "player")
        {
            Player player = collGo.GetComponent<Player>();
            int rand = (int)Random.Range(1f, enemy.accuracy);
            if (rand <= player.dodge)
            {
                print("dodged");
            }
            else
            {
                print("hit");
                player.health -= enemy.damage;
                gm.ShowFloatingText(enemy.damage.ToString(), 24, Color.red, transform.position, Vector3.zero, 0.5f);
            }
            
        }
    }
}
