using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : Mover
{
    public float triggerlenght = 1;
    public float chaselenght = 5;
    private bool chasing;
    private bool collidingwithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;


    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];
    private ContactFilter2D contactFilter;

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetComponentInChildren<BoxCollider2D>();
    }

    private void FixedUpdate()
    {

        if (Vector3.Distance(playerTransform.position, startingPosition) < chaselenght)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerlenght)
            {
                chasing = true;
            }

            if (chasing)
            {
                if (!collidingwithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        collidingwithPlayer = false;
        boxCollider.OverlapCollider(contactFilter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }

            if (hits[i].tag == "fighter" && hits[i].tag == "player")
            {
                collidingwithPlayer = true;
            }

            hits[i] = null;
        }
    }
}
