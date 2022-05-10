using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHitBox : PlayerCollisions
{
    public int damage;
    public float pushForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fighter" && collision.tag == "player")
        {
            // Createa new damage object, before sending it to the player
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };
            collision.SendMessage("ReceiveDamage", dmg);
        }
    }
}
