using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class LowOxygen : UI_Perk
{
    private protected override void Purchase()
    {
        // Infected time increase???? KEKW
        Perks.DeathRate += 0.05f;
    }
}
