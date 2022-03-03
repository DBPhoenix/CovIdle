using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class MutationOverloadPerk : UI_Perk
{
    private protected override void Purchase()
    {
        Resources.FindObjectsOfTypeAll<MutationOverload>()[0].Status = BuildingStatus.Enabled;
    }
}
