using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class AntiVaxxersPerk : UI_Perk
{
    private protected override void Purchase()
    {
        GameObject.Find("Anti Vaxxers").GetComponent<UI_Building>().Status = BuildingStatus.Enabled;
    }
}
