using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Virus : UI_Perk
{
    private new void Start()
    {
        base.Start();

        Status = PerkStatus.Enabled;
    }

    private protected override void Purchase()
    {
        Resources.FindObjectsOfTypeAll<SpreadVirus>()[0].Status = BuildingStatus.Enabled;
    }
}
