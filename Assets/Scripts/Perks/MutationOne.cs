using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class MutationOne : UI_Perk
{
    private protected override void Purchase()
    {
        Perks.MutationModifier += 1f;
    }
}
