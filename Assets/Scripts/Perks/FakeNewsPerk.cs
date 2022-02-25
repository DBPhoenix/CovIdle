using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class FakeNewsPerk : UI_Perk
{
    private protected override void Purchase()
    {
        GameObject.Find("Fake News").GetComponent<UI_Building>().Status = BuildingStatus.Enabled;
    }
}
