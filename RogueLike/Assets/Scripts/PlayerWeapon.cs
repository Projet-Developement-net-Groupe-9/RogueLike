using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;

    public Player player;
    public AudioSource swingAudio;

    public string anim;
    public int damage = 1;
    public float coolDown = 0.5f;
    public float lastSwing;
    public bool swing;
    public int hitVal;

    private void InitVar()
    {
        gm = GameManager.instance;
        go = gameObject;
        player = GetComponentInParent<Player>();
        anim = "WeaponHitRight";
    }

    private void HandleKeys()
    {
        if (Input.GetKeyDown(KeyCode.Space) && MainMenu.begin == true)
        {
            if (!swing)
            {
                lastSwing = Time.time;
                swingAudio.Play();
                Swing();
            }
        }
    }

    private void UpdateSwing()
    {
        if (Time.time - lastSwing > coolDown)
        {
            lastSwing = Time.time;
            swing = false;
        }
    }

    private void Swing()
    {
        swing = true;
        player.animator.Play(anim, 0, 0.0f);
    }


    public void PlayerWeaponStart()
    {
        InitVar();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collGo = collision.gameObject;

        if (collGo.tag == "enemy")
        {
            Enemy enemy = collGo.GetComponent<Enemy>();
            enemy.health -= player.damage;
            enemy.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject collGo = collision.gameObject;

        if (collGo.tag == "enemy")
        {
            Enemy enemy = collGo.GetComponent<Enemy>();
            enemy.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
    }

    private void Update()
    {
        HandleKeys();
        UpdateSwing();
    }
}
