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

    private static bool s_once;
    private static bool s_show;

    public double Cost;
    public double CostModifier = 2;

    public string Description;

    public double Multiplier;

    private BuildingStatus _status;

    private bool _isPointerOver = false;
    private int _purchaseCount = 0;

    private UI_Text _name;
    private UI_Text _price;

    private protected AudioSource _audio;

    private void Awake()
    {
        _name = transform.Find("Name").GetComponent<UI_Text>();
        _price = transform.Find("Price").GetComponent<UI_Text>();

        _audio = GetComponent<AudioSource>();
    }

    private protected void Start()
    {
        _price.SetValue(Cost);
    }

    private void OnEnable()
    {
        if (!s_once)
        {
            s_once = true;
            s_show = true;
        }
    }

    public void Update()
    {
        if (_isPointerOver)
        {
            UI_Tooltip.Instance.SetPosition(Input.mousePosition);
        }

        if (s_show && !UI_PerkTree.Instance.gameObject.activeSelf)
        {
            s_show = false;

            UI_Death.Instance.Display(new string[] {
                "Oh look at that, you can now spend deaths to improve Covid-19! You can always mouse over the upgrades later to get more information.",
                "Spread Covid-19 more to generate deaths, and when you can afford it, why don't you give it a try and see what happens..."
            });
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlanetCanvasManager.Instance.Planet.Deaths > Cost)
        {
            PlanetCanvasManager.Instance.Planet.Deaths -= Cost;

            Purchase();

            _audio.Play();

            IncreaseCost();

            _name.SetValue($"{++_purchaseCount}x {transform.name}");
            _price.SetValue(Cost);

            PlanetCanvasManager.Instance.UpdateStats();

            SetTooltip();
        }
    }

    private void SetTooltip()
    {
        UI_Tooltip.Instance.SetHeader(gameObject.name);
        UI_Tooltip.Instance.SetDescription(Description);
        UI_Tooltip.Instance.Display();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetTooltip();

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

    public void SetName(string name)
    {
        _name.SetValue(name);
    }

    private protected abstract void IncreaseCost();

    private protected abstract void Purchase();
}

public enum BuildingStatus
{
    Disabled,
    Enabled
}
