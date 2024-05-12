using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunEnemy : Enemy
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Transform aim;
    [SerializeField] private float shootDelay;
    

    public override void Move(Vector2 direction, float angle)
    {
        base.Move(direction, angle);

        //rotate with player position when within attack distance
        if(rigidbody.velocity == Vector2.zero)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        
    }

    private void Awake()
    {
        StartCoroutine(AutoAttack());
    }

    IEnumerator AutoAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootDelay);
            Attack();
        }
    }

    public override void Attack()
    {
        if(inAttackRange)
        {
            weapon.Shoot(aim.position, transform.rotation, "Player");
        }
        
    }

    public override void Die()
    {
        base.Die();
        StopAllCoroutines();
    }
}
