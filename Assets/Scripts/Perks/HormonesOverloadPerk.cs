using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class HormonesOverloadPerk : UI_Perk
{
    private protected override void Purchase()
    {
        Resources.FindObjectsOfTypeAll<HormonesOverload>()[0].Status = BuildingStatus.Enabled;
    }
}
