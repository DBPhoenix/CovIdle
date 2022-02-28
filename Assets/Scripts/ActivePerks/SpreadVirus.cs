using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SpreadVirus : UI_ActivePerk
{
    private protected override void IncreaseCost()
    {
        Cost = Math.Floor(Cost * 1.2f);
    }

    private protected override void Purchase()
    {
        PlanetCanvasManager.Instance.Planet.NextGeneration();

        GameManager.Instance.UpdateStats();
    }
}
