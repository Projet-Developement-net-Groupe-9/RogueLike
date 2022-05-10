using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;

    public PlayerMove playerMove;
    public PlayerCollisions playerCollisions;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody;
    public Animator animator;

    private void InitComponents()
    {
        playerMove = gameObject.GetComponent<PlayerMove>();
        playerCollisions = gameObject.GetComponent<PlayerCollisions>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    public void PlayerBodyStart()
    {
        InitComponents();
        playerMove.PlayerMoveStart();
        //playerCollisions.PlayerCollisionsStart();
    }

    public void PlayerBodyUpdate()
    {
        playerMove.PlayerMoveUpdate();
    }

    public void PlayerBodyFixedUpdate()
    {
        playerMove.PlayerMoveFixedUpdate();
    }
}
