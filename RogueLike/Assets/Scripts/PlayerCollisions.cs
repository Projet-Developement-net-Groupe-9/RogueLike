using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;

    private Player player;
    public AudioSource coinAudio, doorAudio;

    private void InitObjects()
    {
        gm = GameManager.instance;
        go = gameObject;
    }

    private void InitComponents()
    {
        player = gameObject.GetComponent<Player>();
    }

    private void InitAll()
    {
        InitObjects();
        InitComponents();
    }

    public void PlayerCollisionsStart()
    {
        InitAll();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collGo = collision.gameObject;

        if (collGo.tag == "transparent")
        {
            Tilemap tilemap = collGo.GetComponent<Tilemap>();
            tilemap.color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (collGo.tag == "coin")
        {
            Coin coin = collGo.GetComponent<Coin>();
            coinAudio.Play();
            player.coins += coin.value;
            gm.ShowFloatingText("+ " + coin.value, 24, Color.yellow, transform.position, Vector3.up * 50, 10f);
            Destroy(collGo);
        }

        if (collGo.tag == "heal")
        {
            Heal heal = collGo.GetComponent<Heal>();
            if (player.health < player.maxHealth)
            {
                player.health += heal.value;
                gm.ShowFloatingText("+++", 26, Color.green, transform.position, Vector3.up * 50, 10f);
                Destroy(collGo);
            }
        }

        if (collGo.tag == "exit")
        {
            gm.scene = collGo.name;
            gm.UpdateState();
            gm.SaveState();
            gm.roomCpt++;
            SceneManager.LoadScene(collGo.name, LoadSceneMode.Single);
            doorAudio.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject collGo = collision.gameObject;

        if (collGo.tag == "transparent")
        {
            Tilemap tilemap = collGo.GetComponent<Tilemap>();
            tilemap.color = new Color(1f, 1f, 1f, 1f);
        }

        if (collGo.tag == "enemy")
        {
            collGo.GetComponentInParent<EnemyMove>().collMult = 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collGo = collision.gameObject;

        if (collGo.tag == "enemy")
        {
            collGo.GetComponentInParent<EnemyMove>().collMult = 0;
        }
    }
}
