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
            player.health -= enemy.damage;
            GameManager.instance.ShowFloatingText(enemy.damage.ToString(), 24, Color.red, transform.position, Vector3.zero, 0.5f);
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    collGo = collision.gameObject;

    //    if (collGo.tag == "transparent")
    //    {
    //        Tilemap tilemap = collGo.GetComponent<Tilemap>();
    //        tilemap.color = new Color(1f, 1f, 1f, 0.5f);
    //    }

    //    if (collGo.tag == "coin")
    //    {
    //        Coin coin = collGo.GetComponent<Coin>();
    //        player.coins += coin.value;
    //        gm.ShowFloatingText("+ " + coin.value, 24, Color.yellow, transform.position, Vector3.up * 50, 10f);
    //        Destroy(collGo);
    //    }

    //    if (collGo.tag == "exit")
    //    {
    //        gm.scene = collGo.name;
    //        gm.UpdateState();
    //        //gm.SaveState();
    //        SceneManager.LoadScene(collGo.name, LoadSceneMode.Single);
    //    }

    //    if (collGo.tag == "enemy")
    //    {
    //        collGo.GetComponentInParent<EnemyMove>().collMult = 0;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    collGo = collision.gameObject;

    //    if (collGo.tag == "transparent")
    //    {
    //        Tilemap tilemap = collGo.GetComponent<Tilemap>();
    //        tilemap.color = new Color(1f, 1f, 1f, 1f);
    //    }

    //    if (collGo.tag == "enemy")
    //    {
    //        collGo.GetComponentInParent<EnemyMove>().collMult = 1;
    //    }
    //}
}
