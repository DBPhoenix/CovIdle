using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class WhiteAir : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.NaturalResistanceModifier += 0.025f;
        Perks.InfectionRate += 0.025f;
    }
}
