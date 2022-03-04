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

        if (s_show && !UI_PerkTree.Instance.gameObject.activeSelf)
        {
            s_show = false;

            UI_Death.Instance.Display(new string[] {
                "Don't worry, this is the last thing, I'll tell you for now. Learning to become a Grim Reaper is hard work.",
                "Look at the new Active Perk, you just unlocked. Active Perks is a way to repeatedly spend Mutation Points.",
                "This first Active Perk will be your main way to spread Covid-19! Hovering over it will display some new information.",
                "Time to try it out!"
            });
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
