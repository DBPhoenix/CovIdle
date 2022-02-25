using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class InfectionOne : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.InfectionRate += 0.05f;
    }
}
