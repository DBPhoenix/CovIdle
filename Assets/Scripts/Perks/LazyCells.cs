using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class LazyCells : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.InfectedCarryOverRate += 0.05f;
    }
}
