using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public sealed class SpreadVirus : UI_ActivePerk, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private protected override void IncreaseCost()
    {
        Cost = Math.Floor(Cost * 1.2f);
    }

    public new void Update()
    {
        if (_isPointerOver)
        {
            UI_Tooltip.Instance.SetPosition(Input.mousePosition);
            UI_Tooltip.Instance.SetDescription($"{Description}\nNext Generation:\n+ ~{Math.Floor(PlanetCanvasManager.Instance.Planet.EstimateNewInfections())} infections\n+ ~{Math.Floor(PlanetCanvasManager.Instance.Planet.EstimateNewDeaths())} deaths\nCost: {Cost} Mutations");
        }
    }

    public new void OnPointerEnter(PointerEventData eventData)
    {
        UI_Tooltip.Instance.SetHeader(gameObject.name);
        UI_Tooltip.Instance.SetDescription($"{Description}\nNext Generation:\n+ ~{Math.Floor(PlanetCanvasManager.Instance.Planet.EstimateNewInfections())} infections\n+ ~{Math.Floor(PlanetCanvasManager.Instance.Planet.EstimateNewDeaths())} deaths\nCost: {Cost} Mutations");
        UI_Tooltip.Instance.Display();

        _isPointerOver = true;
    }

    public new void OnPointerExit(PointerEventData eventData)
    {
        UI_Tooltip.Instance.Hide();

        _isPointerOver = false;
    }

    private protected override void Purchase()
    {
        PlanetCanvasManager.Instance.Planet.NextGeneration();

        GameManager.Instance.UpdateStats();
    }
}
