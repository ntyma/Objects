using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Nuke: on left-mouse click all game entities on scene are destroyed excepty for player
public class Nuke : PickUp
{

    protected override void PickMe(Character characterToChange)
    {
        base.PickMe(characterToChange);
        characterToChange.GetComponent<Player>().PickedUpNuke();
    }
}
