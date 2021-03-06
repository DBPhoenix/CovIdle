using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HormonesOverload : UI_ActivePerk
{
    private protected override void IncreaseCost()
    {
        Cost = Math.Floor(Cost * 2.2f);
    }

    private protected override void Purchase()
    {
        PlanetCanvasManager.Instance.Planet.Deaths *= 2;

        GameManager.Instance.UpdateStats();
    }
}
