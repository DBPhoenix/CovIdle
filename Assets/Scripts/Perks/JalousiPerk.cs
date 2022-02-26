using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class JalousiPerk : UI_Perk
{
    private protected override void Purchase()
    {
        Resources.FindObjectsOfTypeAll<Jalousi>()[0].Status = BuildingStatus.Enabled;
    }
}
