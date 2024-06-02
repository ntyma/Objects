using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPowerUp : PickUp
{
    protected override void PickMe(Character characterToChange)
    {
        base.PickMe(characterToChange);
        characterToChange.GetComponent<Player>().PickedUpGunPowerUp();
    }
}
