using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitPoint = 5;
    public int maxHitPoint = 5;
    public float pushRecoverySpeed = 0.1f;

    protected float immuneTime = 1f;
    protected float lastImmune;

    protected Vector3 pushDirection;

    //Les gens de la classe "fighter" peuvent recevoir des dégâts et mourir
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitPoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowFloatingText(dmg.damageAmount.ToString(), 24, Color.red, transform.position, Vector3.zero, 0.5f);

            if (hitPoint <= 0)
            {
                hitPoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death() //virtual c'est zarma une méthode qui va être redéfini comme un override
    {
        GameManager.instance.ShowFloatingText("Dead", 24, Color.blue, transform.position, Vector3.zero, 0.5f);
        Destroy(gameObject);
    }
}
