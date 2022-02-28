using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_ActivePerk : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public BuildingStatus Status
    {
        get => _status;
        set => SetStatus(value);
    }

    public double Cost;

    public string Description;

    public double Multiplier;

    private BuildingStatus _status;

    private bool _isPointerOver = false;
    private int _purchaseCount = 0;

    public void Update()
    {
        if (_isPointerOver)
        {
            UI_Tooltip.Instance.SetPosition(Input.mousePosition);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (UI_Overview.Instance.Mutations > Cost)
        {
            UI_Overview.Instance.Mutations -= Cost;

            Purchase();

            IncreaseCost();

            PlanetCanvasManager.Instance.UpdateStats();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_Tooltip.Instance.SetHeader(gameObject.name);
        UI_Tooltip.Instance.SetDescription($"{Description}\nCost: {Cost} Mutations");
        UI_Tooltip.Instance.Display();

        _isPointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_Tooltip.Instance.Hide();

        _isPointerOver = false;
    }

    private void SetStatus(BuildingStatus value)
    {
        _status = value;

        switch (_status)
        {
            case BuildingStatus.Disabled:
            {
                gameObject.SetActive(false);
                break;
            }
            case BuildingStatus.Enabled:
            {
                gameObject.SetActive(true);
                break;
            }
        }
    }

    private protected abstract void IncreaseCost();

    private protected abstract void Purchase();
}
