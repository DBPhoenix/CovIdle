using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Perk : Button, IPointerEnterHandler, IPointerExitHandler
{
    public PerkStatus Status
    {
        get => _status;
        set => SetStatus(value);
    }
    public Sprite Icon;

    public string Description;

    private PerkStatus _status;

    private bool _isPointerOver = false;

    private GameObject _disabled;
    private GameObject _enabled;
    private GameObject _purchased;

    private new void Start()
    {
        base.Start();

        _disabled = transform.Find("Disabled").gameObject;
        _enabled = transform.Find("Enabled").gameObject;
        _purchased = transform.Find("Purchased").gameObject;

        transform.Find("Icon").GetComponent<Image>().sprite = Icon;

        onClick.AddListener(Purchase);
    }

    public void Update()
    {
        if (_isPointerOver)
        {
            UI_Tooltip.Instance.SetPosition(Input.mousePosition);
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

    private void SetStatus(PerkStatus value)
    {
        _status = value;

        if (_disabled && _enabled && _purchased)
        {
            if (_disabled.activeSelf)
            {
                _disabled.SetActive(false);
            }
            if (_enabled.activeSelf)
            {
                _enabled.SetActive(false);
            }
            if (_purchased.activeSelf)
            {
                _purchased.SetActive(false);
            }

            switch (_status)
            {
                case PerkStatus.Disabled:
                {
                    _disabled.SetActive(true);
                    break;
                }
                case PerkStatus.Enabled:
                {
                    _enabled.SetActive(true);
                    break;
                }
                case PerkStatus.Purchased:
                {
                    _purchased.SetActive(true);
                    break;
                }
            }
        }
    }

    private protected abstract void Purchase();
}

public enum PerkStatus
{
    Disabled,
    Enabled,
    Purchased
}
