using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class FakeNewsPerk : UI_Perk
{
    private protected override void Purchase()
    {
        Resources.FindObjectsOfTypeAll<Disbelievers>()[0].Status = BuildingStatus.Enabled;
    }
}
