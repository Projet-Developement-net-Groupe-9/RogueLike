using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 movedelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1f;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        movedelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        if (movedelta.x > 0)
            transform.localScale = Vector3.one;
        else if (movedelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        movedelta += pushDirection;
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, movedelta.y), Mathf.Abs(movedelta.y * Time.deltaTime), LayerMask.GetMask());
        if (hit.collider == null)
        {
            transform.Translate(0, movedelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, movedelta.x), Mathf.Abs(movedelta.x * Time.deltaTime), LayerMask.GetMask());
        if (hit.collider == null)
        {
            transform.Translate(movedelta.x * Time.deltaTime, 0, 0);
        }
    }
}
   
