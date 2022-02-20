using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Planet : Button
{
    public PlanetData PlanetData;

    private new void Start()
    {
        onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        UI_Overview.Instance.Close();

        GameManager.Instance.OpenPlanet(PlanetData);
    }
}
