using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickUp
{
    [SerializeField] private Weapon newWeapon;

    protected override void PickMe(Character characterToChange)
    {
        base.PickMe(characterToChange);
    }
}
