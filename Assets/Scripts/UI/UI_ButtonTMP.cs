using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UI_ButtonTMP : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Button _button;
    Image _buttonImage;
    ColorBlock _colors;
    TextMeshProUGUI _text;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _buttonImage = GetComponent<Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        _colors = _button.colors;

        _buttonImage.color = _colors.normalColor;
        _text.color = _colors.normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _buttonImage.color = _colors.highlightedColor;
        _text.color = _colors.highlightedColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _buttonImage.color = _colors.normalColor;
        _text.color = _colors.normalColor;
    }
}
