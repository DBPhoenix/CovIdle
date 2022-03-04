using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class MutationOnInfection : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.MutationPointsFromInfected = 2f;
    }
}
