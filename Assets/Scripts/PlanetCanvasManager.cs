using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetCanvasManager : MonoBehaviour
{
    public static PlanetCanvasManager Instance;

    [HideInInspector]
    public Planet Planet;

    [SerializeField]
    private UI_Text[] _uiElements;

    private Image _map;
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
            _uiByName["Temperature"].SetValue(Planet.Temperature.ToString("N1"));
        }
    }

    private void QuickFix()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !UI_PerkTree.Instance.gameObject.activeSelf)
        {
            Close();
        }
    }
}
