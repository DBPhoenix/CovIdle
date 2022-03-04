using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Infection : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.InfectionRate += 0.05f;
        Perks.MutationModifier += 0.5f;
        Perks.MeetingsPerInfected += 0.5f;
    }
}
