using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ExplodingEnemy : Enemy
{
    public ExplodingEnemy()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(target.tag))
        {
            collision.GetComponent<IDamageable>().ReceiveDamage(10);

            Invoke(nameof(Die), 0.75f);
        }
    }
}
