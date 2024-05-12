using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineBox : PickUp
{
    protected override void PickMe(Character characterToChange)
    {
        base.PickMe(characterToChange);
        characterToChange.GetComponent<Player>().HealPlayer();
    }
}
