using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Temperature : UI_Building
{
    public bool Cold;

    private void Start()
    {
        if (Cold)
        {
            gameObject.name = "Ice Age";
        }
        else
        {
            gameObject.name = "Global Warming";
        }
    }

    private protected override void IncreaseCost()
    {
        Cost *= 2;
    }

    private protected override void Purchase()
    {
        if (Cold)
        {
            // DECREASE TEMPERATURE
        }
        else
        {
            // INCREASE TEMPERATURE
        }
    }
}
