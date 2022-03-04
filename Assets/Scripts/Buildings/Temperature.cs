using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Temperature : UI_Building
{
    public bool Cold;
    public Sprite IceAge;
    public Sprite GlobalWarming;

    private new void Start()
    {
        base.Start();

        if (Cold)
        {
            gameObject.name = "Ice Age";
            transform.Find("Image").GetComponent<Image>().sprite = IceAge;
            Description = "As soon as the virus starts killing people, there will be no one left on earth to contribute to Global Warming, thus turning the world back to an Ice Age.\nLowers temperature.";
        }
        else
        {
            gameObject.name = "Global Warming";
            transform.Find("Image").GetComponent<Image>().sprite = GlobalWarming;
            Description = "Everyone starts to realise that the end is near, causing them to start a massive overuse of natural resources, thus resulting in Global Warming.\nRaises temperature.";
        }

        SetName(gameObject.name);
    }

    private protected override void IncreaseCost()
    {
        Cost = Math.Floor(Cost * CostModifier);
    }

    private protected override void Purchase()
    {
        if (Cold)
        {
            PlanetCanvasManager.Instance.Planet.Temperature -= 0.5f;
        }
        else
        {
            PlanetCanvasManager.Instance.Planet.Temperature += 0.5f;
        }

        PlanetCanvasManager.Instance.UpdateStats();
    }
}
