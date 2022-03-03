using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Propaganda : UI_Perk
{
    private protected override void Purchase()
    {
        Resources.FindObjectsOfTypeAll<Disbelievers>()[0].Multiplier += 0.0025f;
        Resources.FindObjectsOfTypeAll<AntiVaxxers>()[0].Multiplier += 0.005f;
    }
}
