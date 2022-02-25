using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class BloodCough : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.InfectionRate += 0.15f;
        Perks.DeathRate += 0.3f;
    }
}
