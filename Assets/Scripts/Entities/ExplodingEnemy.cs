using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ExplodingEnemy : Enemy
{
    //public ExplodingEnemy(float speed, int health) : base(speed, health)
    //{

    //}

    public ExplodingEnemy()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(target.tag))
        {
            Debug.Log("exploding touched: " + target.tag);
            collision.GetComponent<IDamageable>().ReceiveDamage(10);

            //collision.GetComponent<Enemy>().ReceiveDamage();
            Invoke(nameof(Die), 0.75f);
        }
    }
}
