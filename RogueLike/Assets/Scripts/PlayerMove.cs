using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;

    private Player player;
    private PlayerBody playerBody;
    private PlayerWeapon playerWeapon;
    private Ennemi ennemi;

    private float velocity;     
    private float playerSpeed;
    private float speed;
    private int dirId;
    private Vector2 moveDir;

    private void InitObjects()
    {
        gm = GameManager.instance;
        go = this.gameObject;
    }

    private void InitComponents()
    {
        player = gameObject.GetComponent<Player>();
        playerBody = gameObject.GetComponentInChildren<PlayerBody>();
        playerWeapon = gameObject.GetComponentInChildren<PlayerWeapon>();
    }

    private void InitLoadedVars()
    {
        playerSpeed = player.speed;
    }

    private void InitDefaultVars()
    {
        velocity = 0.7f;
    }

    private void InitVars()
    {
        InitLoadedVars();
        InitDefaultVars();
    }

    private void InitAll()
    {
        InitObjects();
        InitComponents();
        InitVars();
    }

    private void HandleKeys()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        dirId = 0;

        if (moveDir != Vector2.zero)
        {
            dirId = 1;

            if (moveDir.x < 0)
                playerBody.spriteRenderer.flipX = true;

            else if (moveDir.x > 0)
                playerBody.spriteRenderer.flipX = false;
        }
    }

    private void HandleSpeed()
    {
        float speedMult;

        if (moveDir.x == 0 || moveDir.y == 0) 
            speedMult = 1f;
        else 
            speedMult = 0.71f;

        speed = velocity * playerSpeed * speedMult;
    }

    private void HandlePosition()
    {
        playerBody.animator.SetInteger("dirValue", dirId); // Animation
        playerBody.rigidBody.MovePosition(playerBody.rigidBody.position + (moveDir * Time.fixedDeltaTime * speed)); // Dépl. joueur
        playerWeapon.transform.position = playerBody.rigidBody.position; // Dépl. arme
    }

    public void PlayerMoveStart()
    {
        InitAll();
    }

    public void PlayerMoveUpdate()
    {
        HandleKeys();
        HandleSpeed();
    }

    public void PlayerMoveFixedUpdate()
    {
        HandlePosition();
    }
}
