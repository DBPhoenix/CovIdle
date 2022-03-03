using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Disbelievers : UI_Building
{
    private protected override void IncreaseCost()
    {
        Cost = Math.Floor(Cost * CostModifier);
    }

    private protected override void Purchase()
    {
        Perks.MeetingsPerInfected += 0.2f;
    }
}
