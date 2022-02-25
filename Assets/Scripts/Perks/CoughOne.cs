using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class CoughOne : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.InfectionRate += 0.075f;
        Perks.DeathRate += 0.07f;
    }
}
