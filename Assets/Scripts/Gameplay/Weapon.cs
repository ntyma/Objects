using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Create Weapon")]

public class Weapon : ScriptableObject
{
    [SerializeField] Bullet bulletReference;
    [SerializeField] int damage;

    public void Shoot(Vector2 position, Quaternion direction, string tag)
    {
        Bullet tmpBullet = GameObject.Instantiate(bulletReference, position, direction);
        tmpBullet.SetUpBullet(tag, damage);
    }

    public Weapon()
    {

    }

    public Weapon(Bullet bulletPrefab)
    {
        bulletReference = bulletPrefab;
    }
}
