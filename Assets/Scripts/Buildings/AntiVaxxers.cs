using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AntiVaxxers : UI_Building
{
    private protected override void IncreaseCost()
    {
        Cost = Math.Floor(Cost * CostModifier);
    }

    private protected override void Purchase()
    {
        Perks.NaturalResistanceModifier += 0.05f;
    }
}
