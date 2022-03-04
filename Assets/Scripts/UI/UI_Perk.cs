using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Perk : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public PerkStatus Status
    {
        get => _status;
        set => SetStatus(value);
    }
    public Sprite Icon;

    public string Description;
    public double Cost;
    public UI_Perk[] LeadsTo;
    public int RequiredCount;

    private PerkStatus _status;

    private bool _isPointerOver = false;

    private protected AudioSource _audio;

    private GameObject _disabled;
    private GameObject _enabled;
    private GameObject _purchased;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();

        _disabled = transform.Find("Disabled").gameObject;
        _enabled = transform.Find("Enabled").gameObject;
        _purchased = transform.Find("Purchased").gameObject;

        transform.Find("Icon").GetComponent<Image>().sprite = Icon;
    }

    private protected void Start()
    {
        ConnectPerks();
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
        if (Status == PerkStatus.Enabled)
        {
            if (UI_Overview.Instance.Mutations > Cost)
            {
                UI_Overview.Instance.Mutations -= Cost;

                Purchase();

                _audio.Play();

                foreach (UI_Perk perk in LeadsTo)
                {
                    perk.RequiredCount--;

                    if (perk.RequiredCount == 0)
                    {
                        perk.Status = PerkStatus.Enabled;
                    }
                }

                Status = PerkStatus.Purchased;
            }
            else
            {
                transform.Find("Icon").GetComponent<Image>().color = new Color(1, 0, 0);

                Invoke("ResetColor", 1);
            }
        }
    }

    private void ResetColor()
    {
        transform.Find("Icon").GetComponent<Image>().color = new Color(1, 1, 1);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_Tooltip.Instance.SetHeader(gameObject.name);
        UI_Tooltip.Instance.SetDescription(Description + $"\nRequires: {Cost} Mutations");
        UI_Tooltip.Instance.Display();

        _isPointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_Tooltip.Instance.Hide();

        _isPointerOver = false;
    }

    private void ConnectPerks()
    {
        foreach (UI_Perk perk in LeadsTo)
        {
            Transform parent = transform.parent;
            while (!parent.name.StartsWith("Tier"))
            {
                parent = parent.parent;
            }

            RectTransform line = GameObject.Instantiate(GameManager.Instance.Line, parent).GetComponent<RectTransform>();
            line.transform.SetAsFirstSibling();

            Vector3 vector = perk.transform.position - transform.position;

            line.sizeDelta = new Vector2(vector.magnitude, 5);
            line.position = transform.position + vector / 2;
            line.right = vector;

            perk.RequiredCount++;
        }
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
