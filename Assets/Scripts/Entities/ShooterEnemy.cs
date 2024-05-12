using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Transform aim;
    [SerializeField] private float shootDelay;
    [SerializeField] private LineRenderer lineRenderer;


    public override void Move(Vector2 direction, float angle)
    {
        base.Move(direction, angle);

        //rotate with player position when within attack distance
        if (rigidbody.velocity == Vector2.zero)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }

    private void Awake()
    {
        
        StartCoroutine(AutoAttack());
    }

    private void Update()
    {
        if (inAttackRange)
        {
            lineRenderer.gameObject.SetActive(true);
        } else
        {
            lineRenderer.gameObject.SetActive(false);
        }
        lineRenderer.SetPosition(0, aim.transform.position);
        lineRenderer.SetPosition(1, target.transform.position);
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
        if (inAttackRange)
        {
            weapon.Shoot(aim.position, transform.rotation, "Player");
        }

    }


    public override void Die()
    {

        StopAllCoroutines();
        base.Die();
    }
}
