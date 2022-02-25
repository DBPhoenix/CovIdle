using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UI_Text : MonoBehaviour
{
    [SerializeField]
    private string _prefix;
    [SerializeField]
    private string _suffix;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void SetValue(string value)
    {
        _text.text = $"{_prefix}{value}{_suffix}";
    }

    public void SetValue(double value)
    {
        _text.text = $"{_prefix}{((int) value).ToString()}{_suffix}";
    }

    public void SetValue(int value)
    {
        _text.text = $"{_prefix}{value.ToString()}{_suffix}";
    }
}
