using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Funeral : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.MeetingsPerInfected += 2f;
        Perks.DeathRate += 0.1f;
    }
}
