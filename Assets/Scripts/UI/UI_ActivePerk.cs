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

    private static bool s_once;
    private protected static bool s_show;

    public double Cost;

    [TextArea]
    public string Description;

    private BuildingStatus _status;

    private protected bool _isPointerOver = false;

    private protected AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (_isPointerOver)
        {
            UI_Tooltip.Instance.SetPosition(Input.mousePosition);
            UI_Tooltip.Instance.SetDescription($"{Description}\nCost: {Cost} Mutations");
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

    private void OnEnable()
    {
        if (!s_once)
        {
            s_once = true;
            s_show = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (UI_Overview.Instance.Mutations > Cost)
        {
            UI_Overview.Instance.Mutations -= Cost;

            Purchase();

            _audio.Play();

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
