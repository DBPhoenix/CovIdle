using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MutationOverload : UI_ActivePerk
{
    private protected override void IncreaseCost()
    {
        Cost = Math.Floor(Cost * 2f);
    }

    private protected override void Purchase()
    {
        UI_Overview.Instance.Mutations *= 2;

        GameManager.Instance.UpdateStats();
    }
}
