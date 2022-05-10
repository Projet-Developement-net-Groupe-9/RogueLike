using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;

    public Player player;

    public string anim;
    public int damage = 1;
    public float coolDown = 0.5f;
    public float lastSwing;
    public bool swing;
    public int hitVal;

    private void InitVar()
    {
        go = this.gameObject;
        player = GetComponentInParent<Player>();
        anim = "WeaponHitRight";
    }

    private void HandleKeys()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!swing)
            {
                lastSwing = Time.time;
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

    void Update()
    {
        HandleKeys();
        UpdateSwing();
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fighter")
        {
            print(collision.gameObject.name);
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = coolDown

            };
            collision.SendMessage("ReceiveDamage", dmg);
        }
    }
}
