using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Planet : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public PlanetData PlanetData;
    public bool Active;

    private bool _isPointerOver = false;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (_isPointerOver)
        {
            UI_Tooltip.Instance.SetDescription($"Infected: {Math.Floor(GameManager.Instance.Planets[PlanetData.name].Infected).ToString()}\nTemperature: {GameManager.Instance.Planets[PlanetData.name].Temperature}");
            UI_Tooltip.Instance.SetPosition(Input.mousePosition);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Active)
        {
            _audio.Play();

            GameManager.Instance.OpenPlanet(PlanetData);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Active)
        {
            UI_Tooltip.Instance.SetHeader(PlanetData.name);
            UI_Tooltip.Instance.SetDescription($"Infected: {Math.Floor(GameManager.Instance.Planets[PlanetData.name].Infected).ToString()}\nTemperature: {GameManager.Instance.Planets[PlanetData.name].Temperature}");
            UI_Tooltip.Instance.Display();

            _isPointerOver = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Active)
        {
            UI_Tooltip.Instance.Hide();

            _isPointerOver = false;
        }
    }
}
