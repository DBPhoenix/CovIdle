using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Germ : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.MeetingsPerInfected += 0.01f;
        Perks.InfectionRate += 0.025f;
    }
}
