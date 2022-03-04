using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class VirusResistance : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.InfectionRate += 0.05f;
        Perks.NaturalResistanceModifier += 0.05f;
    }
}
