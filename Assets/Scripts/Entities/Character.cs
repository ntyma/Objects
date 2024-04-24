using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageable
{

    [SerializeField] protected new Rigidbody2D rigidbody;
    [SerializeField] private float speed;

    private int strength;
    protected Health healthPoints;

    public Character(float speed, int health)
    {
        this.speed = speed;

    }

    public Character()
    {

    }

    protected virtual void Start()
    {
        healthPoints = new Health(5);
    }

    public void ReceiveDamage()
    {
        healthPoints.DecreaseLife();
    }

    public void ReceiveDamage(int damage)
    {
        healthPoints.DecreaseLife(damage);
    }

    public abstract void Attack();

    public abstract void Die();

    public virtual void Move(Vector2 direction, float angle)
    {
        //rigidbody.velocity = direction * speed * Time.deltaTime;
        rigidbody.AddForce(direction.normalized * speed * Time.deltaTime * 100f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    
}
