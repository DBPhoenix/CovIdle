using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_MouseOverGray : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image _image;

    void Awake()
    {
        _image = GetComponentInChildren<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.color = new Color(0.5f, 0.5f, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.color = new Color(1, 1, 1);
    }
}
