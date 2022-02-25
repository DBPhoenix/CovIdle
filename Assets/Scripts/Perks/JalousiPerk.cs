using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class JalousiPerk : UI_Perk
{
    private protected override void Purchase()
    {
        GameObject.Find("Jalousi").GetComponent<UI_Building>().Status = BuildingStatus.Enabled;
    }
}
