using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Tooltip : MonoBehaviour
{
    public static UI_Tooltip Instance;

    private TextMeshProUGUI _header;
    private TextMeshProUGUI _description;

    private Vector2 _scaledSize;

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

        Transform container = transform.GetChild(0);

        _header = container.Find("Header").GetComponent<TextMeshProUGUI>();
        _description = container.Find("Description").GetComponent<TextMeshProUGUI>();

        Vector2 size = GetComponent<RectTransform>().sizeDelta;

        Vector2 resolution = GetComponentInParent<CanvasScaler>().referenceResolution;
        Vector2 screenScale = new Vector2(resolution.x / Screen.width, resolution.y / Screen.height);

        _scaledSize = size / screenScale;
    }

    private void Start()
    {
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

    public void SetDescription(string text)
    {
        _description.text = text;
    }

    public void SetHeader(string text)
    {
        _header.text = text;
    }

    public void SetPosition(Vector2 position)
    {
        if (position.x + _scaledSize.x > Screen.width)
        {
            transform.position = new Vector2(position.x - _scaledSize.x / 2, position.y - _scaledSize.y / 2);
        }
        else
        {
            transform.position = new Vector2(position.x + _scaledSize.x / 2, position.y - _scaledSize.y / 2);
        }
    }
}
