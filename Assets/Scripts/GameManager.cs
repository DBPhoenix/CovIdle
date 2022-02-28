using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Line;

    [SerializeField]
    private int _generationRepeatRate;

    [Header("Starting Values")]
    [SerializeField]
    private float _meetingsPerInfected;
    [SerializeField]
    private float _infectionRate;
    [SerializeField]
    private float _optimalTemperature;

    private double _totalInfected = 0;

    public Dictionary<string, Planet> Planets = new Dictionary<string, Planet>();

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

        Perks.MeetingsPerInfected = _meetingsPerInfected;
        Perks.InfectionRate = _infectionRate;
        Perks.MinOptimalTemperature = _optimalTemperature;
        Perks.MaxOptimalTemperature = _optimalTemperature;
    }

    private void Start()
    {
        Transform map = GameObject.FindWithTag("Map").transform;

        foreach (Transform child in map)
        {
            UI_Planet planet = child.GetComponent<UI_Planet>();

            if (!planet.Active)
            {
                continue;
            }

            PlanetData data = planet.PlanetData;

            Planets[data.Name] = new Planet(data);
        }

        UpdateStats();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UI_Tooltip.Instance.Hide();
        }

        UI_Overview.Instance.GenerateMutations(_totalInfected);
    }

    public void OpenPlanet(PlanetData data)
    {
        PlanetCanvasManager.Instance.Open(Planets[data.Name]);
    }

    public void UpdateStats()
    {
        _totalInfected = 0;
        double totalDeaths = 0;

        foreach (Planet planet in Planets.Values)
        {
            _totalInfected += planet.Infected;
            totalDeaths += planet.Deaths;
        }

        PlanetCanvasManager.Instance.UpdateStats();
        UI_Overview.Instance.UpdateStats(_totalInfected, totalDeaths);
    }
}
