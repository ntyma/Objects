using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //[SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform aim;
    [SerializeField] private Weapon playerWeapon;
    private Player myPlayer;

    //public Player(float speed, int health) : base(speed, health)
    //{

    //}

    protected override void Start()
    {
        
        myPlayer = GetComponent<Player>();
        healthPoints = new Health(100);
        //playerWeapon = new Weapon(bulletPrefab);

        //Listeners
        healthPoints.OnHealthChanged.AddListener(ChangedHealth);
    }

    public void ChangedHealth(int health)
    {
        Debug.Log("Player life : " + health);
        if (health <= 0)
        {
            //GameManager.singleton.scoreManager.RegisterHighscore();
            //Destroy(gameObject);
            Die();
        }
    }

    public override void Attack()
    {
        //playerWeapon.ShootPlayer(aim.position, aim.rotation);
        playerWeapon.Shoot(transform.position, transform.rotation, "Enemy");
    }

    public override void Die()
    {
        GameManager.singleton.EndGame();
        Destroy(gameObject);
    }

    public override void Move(Vector2 direction, float angle)
    {
        base.Move(direction, angle);
    }

    //public void ReceiveDamage()
    //{
    //    healthPoints.DecreaseLife();
    //}
}