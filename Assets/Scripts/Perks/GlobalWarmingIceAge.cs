using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class GlobalWarmingIceAge : UI_Perk
{
    private protected override void Purchase()
    {
        Resources.FindObjectsOfTypeAll<Temperature>()[0].Status = BuildingStatus.Enabled;
    }
}
