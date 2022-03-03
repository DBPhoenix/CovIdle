using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetCanvasManager : MonoBehaviour
{
    public static PlanetCanvasManager Instance;

    public GameObject BackArrow;

    [HideInInspector]
    public Planet Planet;

    [SerializeField]
    private UI_Text[] _uiElements;

    private Image _map;
    private Dictionary<string, UI_Text> _uiByName = new Dictionary<string, UI_Text>();

    bool _reachedThousandMutation = false;

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

        foreach (UI_Text ui in _uiElements)
        {
            _uiByName.Add(ui.gameObject.name, ui);
        }

        _map = transform.Find("Body").Find("Terrain").GetComponent<Image>();

        gameObject.SetActive(false);
    }

    private void Update()
    {
        QuickFix();
    }

    public void Open(Planet planet)
    {
        Planet = planet;

        gameObject.SetActive(true);

        _uiByName["Name"].SetValue(Planet.Data.Name);

        _map.sprite = planet.Data.Map;

        UpdateStats();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void UpdateStats()
    {
        if (gameObject.activeSelf)
        {
            _uiByName["Infected"].SetValue(Planet.Infected);
            _uiByName["Deaths"].SetValue(Planet.Deaths);
            _uiByName["Mutations"].SetValue(UI_Overview.Instance.Mutations);
            _uiByName["MPS"].SetValue(Math.Log(GameManager.Instance.GetTotalInfected(), 5 - Perks.MutationModifier).ToString("N1"));
            _uiByName["Temperature"].SetValue(Planet.Temperature.ToString("N1"));
            _uiByName["InfectedMeet"].SetValue((Planet.Data.MeetingsPerInfected + Perks.MeetingsPerInfected).ToString("N1"));
        }
    }

    private void QuickFix()
    {

        if (!_reachedThousandMutation)
        {
            if (UI_Overview.Instance.Mutations > 1000)
            {
                _reachedThousandMutation = true;

                BackArrow.SetActive(true);

                // SHOW TUTORIAL
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !UI_PerkTree.Instance.gameObject.activeSelf)
            {
                Close();
            }
        }
    }
}
