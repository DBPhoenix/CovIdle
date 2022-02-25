using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class WhiteAir : UI_Perk
{
    private protected override void Purchase()
    {
        // Decrease Natural Resistance
        Perks.InfectionRate += 0.025f;
    }
}
