using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class OutOfBody : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.InfectionRate += 1;
    }
}
