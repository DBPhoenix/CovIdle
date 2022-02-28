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
        }
        else
        {
            gameObject.name = "Global Warming";
            transform.Find("Image").GetComponent<Image>().sprite = GlobalWarming;
        }

        SetName(gameObject.name);
    }

    private protected override void IncreaseCost()
    {
        Cost *= 2;
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
