using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HormonesOverload : UI_ActivePerk
{
    private protected override void IncreaseCost()
    {
        Cost = Math.Floor(Cost * 1.4f);
    }

    private protected override void Purchase()
    {
        PlanetCanvasManager.Instance.Planet.Population.Uninfected[10].Size *= 0.95f;

        GameManager.Instance.UpdateStats();
    }
}
