using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class RedBloodCellsOverload : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.NaturalResistanceModifier += 0.1f;
    }
}
