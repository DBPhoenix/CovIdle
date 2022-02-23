using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private int _generationRepeatRate;

    [Header("Starting Values")]
    [SerializeField]
    private float _meetingsPerInfected;
    [SerializeField]
    private float _infectionRate;
    [SerializeField]
    private float _optimalTemperature;

    private Dictionary<string, Planet> _planets = new Dictionary<string, Planet>();

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

            _planets[data.Name] = new Planet(data);
        }

        InvokeRepeating("NextGeneration", 0, _generationRepeatRate);
    }

    public void OpenPlanet(PlanetData data)
    {
        PlanetCanvasManager.Instance.Open(_planets[data.Name]);
    }

    private void NextGeneration()
    {
        float totalInfected = 0;
        float totalDeaths = 0;

        foreach (Planet planet in _planets.Values)
        {
            planet.NextGeneration();

            totalInfected += planet.Infected;
            totalDeaths += planet.Deaths;
        }

        UI_Overview.Instance.GenerateMutations(totalInfected);

        PlanetCanvasManager.Instance.UpdateStats();
        UI_Overview.Instance.UpdateStats((int) totalInfected, (int) totalDeaths);
    }
}
