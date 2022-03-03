using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class LowOxygen : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.InfectedCarryOverRate += 0.2f;
        Perks.DeathRate += 0.5f;
    }
}
