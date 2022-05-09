using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;
    public GameObject collGo;


    private Player player;


    private void InitObjects()
    {
        gm = GameManager.instance;
        go = this.gameObject;
    }

    private void InitComponents()
    {
        player = gameObject.GetComponentInParent<Player>();
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
        collGo = collision.gameObject;

        if (collGo.tag == "transparent")
        {
            Tilemap tilemap = collGo.GetComponent<Tilemap>();
            tilemap.color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (collGo.tag == "coin")
        {
            Coin coin = collGo.GetComponent<Coin>();
            player.coins += coin.value;
            gm.ShowFloatingText("+ " + coin.value, 24, Color.yellow, transform.position, Vector3.up * 50, 10f);
            Destroy(collGo);
        }

        if (collGo.tag == "exit")
        {
            gm.scene = collGo.name;
            gm.UpdateState();
            //gm.SaveState();
            SceneManager.LoadScene(collGo.name, LoadSceneMode.Single);
        }

        if (collGo.name == "ennemi_1")
        {
            Ennemi ennemi = collGo.GetComponent<Ennemi>();
            player.health--;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collGo = collision.gameObject;

        if (collGo.tag == "transparent")
        {
            Tilemap tilemap = collGo.GetComponent<Tilemap>();
            tilemap.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
