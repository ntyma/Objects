using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    [SerializeField] protected float attackDistance;
    protected Player target;
    [SerializeField] protected float time;

    [SerializeField] protected bool inAttackRange;
    

    //public Enemy(float speed, int health)
    //{
    //    this.speed = speed;
    //    healthPoints = new Health(health);
    //}


    public Enemy()
    {
        
    }

    protected override void Start()
    {
        
    }

    //called when the enemy is instantiated in GameManager
    public void SetUpEnemy(int healthParam)
    {
        healthPoints = new Health(healthParam);
        target = FindAnyObjectByType<Player>();

        //Listeners
        healthPoints.OnHealthChanged.AddListener(ChangedHealth);
    }

  

    public void ChangedHealth(int health)
    {
        Debug.Log("Enemy Life has changed: " + health);
        if (health <= 0)
        {
            //increase score
            ScoreManager.singleton.IncreaseScore();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            Vector2 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Move(direction, angle);
        }
    }

    public override void Move(Vector2 direction, float angle)
    {
        if(Vector2.Distance(target.transform.position, transform.position) > attackDistance)
        {
            base.Move(direction, angle);
            //Debug.Log("NOT in attack range");
            inAttackRange = false;
        } else
        {
            //stop immediately
            rigidbody.velocity = Vector2.zero;
            //Debug.Log("in attack range");
            inAttackRange = true;

            if(attackDistance < 1)
            {
                time += Time.deltaTime;
                if (time >= 2f)
                {
                    target.ReceiveDamage();
                    time = 0f;
                }
            }
        }
        
    }

    //public override void ReceiveDamage()
    //{
    //    Debug.Log("Enemy take damage");
    //}

    public override void Attack()
    {
       
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
