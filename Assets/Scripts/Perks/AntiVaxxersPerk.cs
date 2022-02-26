using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class AntiVaxxersPerk : UI_Perk
{
    private protected override void Purchase()
    {
        Resources.FindObjectsOfTypeAll<AntiVaxxers>()[0].Status = BuildingStatus.Enabled;
    }
}
