using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class ChaosPerk : UI_Perk
{
    private protected override void Purchase()
    {
        GameObject.Find("Chaos").GetComponent<UI_Building>().Status = BuildingStatus.Enabled;
    }
}
