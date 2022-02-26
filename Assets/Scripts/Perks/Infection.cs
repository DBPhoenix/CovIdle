using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Infection : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.InfectionRate += 0.02f;
        Perks.MutationModifier += 0.05f;
        Perks.MeetingsPerInfected += 0.1f;
    }
}
