using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Building : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
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

    private UI_Text _name;
    private UI_Text _price;

    private void Awake()
    {
        _name = transform.Find("Name").GetComponent<UI_Text>();
        _price = transform.Find("Price").GetComponent<UI_Text>();
    }

    private void Start()
    {
        _price.SetValue(Cost);
    }

    public void Update()
    {
        if (_isPointerOver)
        {
            UI_Tooltip.Instance.SetPosition(Input.mousePosition);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlanetCanvasManager.Instance.Planet.Deaths > Cost)
        {
            PlanetCanvasManager.Instance.Planet.Deaths -= Cost;

            Purchase();

            IncreaseCost();

            _name.SetValue($"{++_purchaseCount}x {transform.name}");
            _price.SetValue(Cost);

            PlanetCanvasManager.Instance.UpdateStats();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_Tooltip.Instance.SetHeader(gameObject.name);
        UI_Tooltip.Instance.SetDescription(Description);
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

public enum BuildingStatus
{
    Disabled,
    Enabled
}
