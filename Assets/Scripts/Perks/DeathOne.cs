using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class DeathOne : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.DeathRate += 0.05f;
    }
}
