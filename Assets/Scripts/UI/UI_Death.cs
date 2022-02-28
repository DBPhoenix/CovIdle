using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Death : MonoBehaviour
{
    public static UI_Death Instance;

    TextMeshProUGUI _text;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _text = GetComponentInChildren<TextMeshProUGUI>();

        Hide();
    }

    public void Display()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}
