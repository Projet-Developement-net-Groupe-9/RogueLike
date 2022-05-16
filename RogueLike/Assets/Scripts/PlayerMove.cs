using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;

    private Player player;
    private PlayerWeapon playerWeapon;

    private float playerSpeed;
    private float speed;
    private int dirId;
    private Vector2 moveDir;

    private void InitObjects()
    {
        gm = GameManager.instance;
        go = gameObject;
    }

    private void InitComponents()
    {
        player = gameObject.GetComponent<Player>();
        playerWeapon = gameObject.GetComponentInChildren<PlayerWeapon>();
    }

    private void InitVars()
    {
        playerSpeed = player.speed;
    }

    private void InitAll()
    {
        InitObjects();
        InitComponents();
        InitVars();
    }

    private void HandleKeys()
    {
        if (MainMenu.begin == true)
        {
            moveDir.x = Input.GetAxisRaw("Horizontal");
            moveDir.y = Input.GetAxisRaw("Vertical");

            dirId = 0;

            if (moveDir != Vector2.zero)
            {
                dirId = 1;

                if (moveDir.x < 0)
                {
                    player.spriteRenderer.flipX = true;
                    playerWeapon.anim = "WeaponHitLeft";
                }

                else if (moveDir.x > 0)
                {
                    player.spriteRenderer.flipX = false;
                    playerWeapon.anim = "WeaponHitRight";
                }
            }

            if(Input.GetKey(KeyCode.Escape))
            {
                if (MainMenu.begin == true)
                    Destroy(gm);
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
        }
    }

    private void HandleSpeed()
    {
        float speedMult;

        if (moveDir.x == 0 || moveDir.y == 0) 
            speedMult = 1f;
        else 
            speedMult = 0.71f;

        speed = gm.velocity * playerSpeed * speedMult;
    }

    private void HandlePosition()
    {
        player.animator.SetInteger("dirValue", dirId); // Animation
        player.rigidBody.MovePosition(player.rigidBody.position + (moveDir * Time.fixedDeltaTime * speed)); // Dépl. joueur
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
