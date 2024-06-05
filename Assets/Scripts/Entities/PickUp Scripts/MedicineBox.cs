using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineBox : PickUp
{
    protected override void PickMe(Character characterToChange)
    {
        characterToChange.GetComponent<Player>().HealPlayer();
        base.PickMe(characterToChange);
    }

}
