using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Planet : Button
{
    public PlanetData PlanetData;
    public bool Active;

    private new void Start()
    {
        gameObject.SetActive(Active);

        onClick.AddListener(OnClick);

        base.Start();
    }

    public void OnClick()
    {
        UI_Overview.Instance.Close();

        GameManager.Instance.OpenPlanet(PlanetData);
    }
}
