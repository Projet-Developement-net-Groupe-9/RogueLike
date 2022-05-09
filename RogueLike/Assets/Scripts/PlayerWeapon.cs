using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;
    
    public Animator animator;

    public int id = 0;
    //public int reach = 1;
    public int damage = 1;

    private float coolDown = 0.5f;
    private float lastSwing;
    private bool swing;

    private SpriteRenderer spriteRenderer;

    private void InitVar()
    {
        go = this.gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
            animator.SetBool("Swing", false);
        }
            
    }

    private void Swing()
    {
        swing = true;
        animator.SetBool("Swing", true);
    }
    

    void Start()
    {
        InitVar();
    }

    void Update()
    {
        HandleKeys();
        UpdateSwing();
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
