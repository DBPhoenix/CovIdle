using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCanvasManager : MonoBehaviour
{
    public static PlanetCanvasManager Instance;

    [HideInInspector]
    public Planet Planet;

    [SerializeField]
    private UI_Text[] _uiElements;

    private Dictionary<string, UI_Text> _uiByName = new Dictionary<string, UI_Text>();

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
            _uiByName["Infected"].SetValue((int) Planet.Infected);
            _uiByName["Deaths"].SetValue((int) Planet.Deaths);
        }
    }

    private void QuickFix()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }
}
