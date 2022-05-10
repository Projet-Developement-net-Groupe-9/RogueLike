using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    public GameManager gm;
    public GameObject go;

    public PlayerCollisions playerCollisions;
    public PlayerBody playerBody;
    public PlayerWeapon playerWeapon;
    public Animator animator;

    public int health;
    public int coins;
    public float speed;
    public int maxHealth;

    private void InitObjects()
    {
        gm = GameManager.instance;
        go = this.gameObject;
    }

    private void InitComponents()
    {
        playerCollisions = GetComponent<PlayerCollisions>();
        playerBody = GetComponent<PlayerBody>();
        playerWeapon = GetComponentInChildren<PlayerWeapon>();   
        animator = GetComponent<Animator>();
    }

    private void InitLoadedVars()
    {
        health = gm.health;
        coins = gm.coins;
        speed = gm.speed;
        maxHealth = gm.maxHealth;
    }

    private void InitDefaultVars()
    {
        health = 5;
        coins = 0;
        speed = 1f;
        maxHealth = health;
    }

    private void InitVars()
    {
        if (gm.health != 0)
        {
            InitLoadedVars();
        }
        else
        {
            InitDefaultVars();
        }
    }

    private void InitGmVars()
    {
        gm.player = this;
    }

    private void InitAll()
    {
        InitObjects();
        InitComponents();
        InitVars();
        InitGmVars();
    }

    private void Start()
    {
        InitAll();
        playerBody.PlayerBodyStart();
        playerCollisions.PlayerCollisionsStart();
        playerWeapon.PlayerWeaponStart();
    }

    private void Update()
    {
        playerBody.PlayerBodyUpdate();
    }

    private void FixedUpdate()
    {
        playerBody.PlayerBodyFixedUpdate();
    }
}
