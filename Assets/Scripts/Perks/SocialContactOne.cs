using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class SocialContactOne : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.MeetingsPerInfected += 0.2f;
    }
}
