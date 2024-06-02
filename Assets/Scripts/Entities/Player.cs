using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : Character
{
    //[SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform aim;
    [SerializeField] private Weapon playerWeapon;
    [SerializeField] private Weapon powerUpWeapon;
    [SerializeField] private int nukeCount = 0;
    [SerializeField] private float shootDelay;
    private float timer;
    //[SerializeField] private Image coolDownImage;

    private Player myPlayer;
    [SerializeField]private UIPlayerManager uiManager;

    public UnityEvent<int> OnNukeCountChanged = new UnityEvent<int>();
    public UnityEvent OnPowerUp = new UnityEvent();
    public UnityEvent OnPowerUpEnd = new UnityEvent();

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
        OnNukeCountChanged.AddListener(ChangedNukeCount);
    }

    public void ChangedHealth(int health)
    {
        //Debug.Log("Player life : " + health);
        UIGamePlay.singleton.UpdateUIPlayerHealthText(health);
        if (health <= 0)
        {
            //GameManager.singleton.scoreManager.RegisterHighscore();
            //Destroy(gameObject);
            Die();
        }
    }

    public void HealPlayer()
    {
        healthPoints.Heal();
    }

    public override void Attack()
    {
        Debug.Log("normal attack");
        //playerWeapon.ShootPlayer(aim.position, aim.rotation);
        playerWeapon.Shoot(aim.transform.position, transform.rotation, "Enemy");
    }

    public void PowerUpAttack()
    {

        Debug.Log("power up attack");

        if(timer > shootDelay)
        {
            powerUpWeapon.Shoot(aim.transform.position, transform.rotation, "Enemy");
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
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

    public void PickedUpNuke()
    {
        nukeCount++;
        OnNukeCountChanged.Invoke(nukeCount);
    }

    public void UseNuke()
    {
        if(nukeCount <= 0)
        {
            return;
        }
        nukeCount--;
        OnNukeCountChanged.Invoke(nukeCount);
        GameManager.singleton.DestroyAllEnemies();
    }

    public void ChangedNukeCount(int nukeCount)
    {
        UIGamePlay.singleton.ChangeNukeGrid(nukeCount);
    }

    public void PickedUpGunPowerUp()
    {
        OnPowerUp.Invoke();
        uiManager.StartCoolDown();
        uiManager.OnCooledDown.AddListener(ChangeWeapon);
    }

    private void ChangeWeapon()
    {
        Debug.Log("Player: Change weapon");
        OnPowerUpEnd.Invoke();
    }

}