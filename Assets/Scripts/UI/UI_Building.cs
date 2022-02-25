using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Building : Button, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public BuildingStatus Status
    {
        get => _status;
        set => SetStatus(value);
    }

    public double Cost;

    public string Description;

    private BuildingStatus _status = BuildingStatus.Enabled;

    private bool _isPointerOver = false;

    private UI_Text _price;

    private new void Start()
    {
        base.Start();

        _price = transform.Find("Price").GetComponent<UI_Text>();

        _price.SetValue(Cost);

        onClick.AddListener(Purchase);
    }

    public void Update()
    {
        if (_isPointerOver)
        {
            UI_Tooltip.Instance.SetPosition(Input.mousePosition);
        }
    }

    public new void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (PlanetCanvasManager.Instance.Planet.Deaths > Cost)
        {
            PlanetCanvasManager.Instance.Planet.Deaths -= Cost;

            Purchase();

            IncreaseCost();

            _price.SetValue(Cost);
        }
    }

    public new void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);

        UI_Tooltip.Instance.SetHeader(gameObject.name);
        UI_Tooltip.Instance.SetDescription(Description);
        UI_Tooltip.Instance.Display();

        _isPointerOver = true;
    }

    public new void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);

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
