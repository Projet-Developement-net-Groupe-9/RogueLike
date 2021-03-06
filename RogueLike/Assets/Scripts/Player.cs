using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;

    public PlayerMove playerMove;
    public PlayerCollisions playerCollisions;
    public PlayerWeapon playerWeapon;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody;
    public Animator animator;

    public int health;
    public int coins;
    public float speed;
    public int damage;
    public int maxHealth;
    public int dodge;
    public bool godMode;
    public int weaponSpriteId;
    public int bestScore;

    private void InitObjects()
    {
        gm = GameManager.instance;
        go = gameObject;
    }

    private void InitComponents()
    {
        playerMove = GetComponent<PlayerMove>();
        playerCollisions = GetComponent<PlayerCollisions>();
        playerWeapon = GetComponentInChildren<PlayerWeapon>();   
        spriteRenderer = GetComponent<SpriteRenderer>();    
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void InitLoadedVars()
    {
        health = gm.health;
        coins = gm.coins;
        speed = gm.speed;
        damage = gm.damage;
        maxHealth = gm.maxHealth;
        dodge = gm.dodge;
        weaponSpriteId = gm.weaponSpriteId;
        bestScore = gm.bestScore;
    }

    private void InitDefaultVars()
    {
        health = 10;
        coins = 0;
        speed = 1f;
        damage = 1;
        maxHealth = health;
        dodge = 1;
        weaponSpriteId = 0;
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

    private void checkHealth()
    {
        if (health > maxHealth)
            health = maxHealth;
        else if (health <= 0)
        {
            health = maxHealth;
            gm.UpdateState();
            gm.SaveState();
            print("Best score : " + gm.bestScore);
            gm.roomCpt = 0;
            SceneManager.LoadScene("DeathMenu", LoadSceneMode.Single);
        }
    }

    private void Start()
    {
        InitAll();
        playerMove.PlayerMoveStart();
        playerCollisions.PlayerCollisionsStart();
        playerWeapon.PlayerWeaponStart();
    }

    private void Update()
    {
        playerMove.PlayerMoveUpdate();
        checkHealth();
        if (godMode)
            health = 10;
    }

    private void FixedUpdate()
    {
        playerMove.PlayerMoveFixedUpdate();
    }
}
