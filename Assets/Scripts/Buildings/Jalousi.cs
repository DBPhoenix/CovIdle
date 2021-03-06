using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Jalousi : UI_Building
{
    private protected override void IncreaseCost()
    {
        Cost = Math.Floor(Cost * CostModifier);
    }

    private protected override void Purchase()
    {
        PlanetCanvasManager.Instance.Planet.Population.Uninfected[10].Size *= 0.95f;
    }
}
