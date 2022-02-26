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

        InvokeRepeating("NextGeneration", 0, _generationRepeatRate);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UI_Tooltip.Instance.Hide();
        }
    }

    public void OpenPlanet(PlanetData data)
    {
        PlanetCanvasManager.Instance.Open(Planets[data.Name]);
    }

    private void NextGeneration()
    {
        double totalInfected = 0;
        double totalDeaths = 0;

        foreach (Planet planet in Planets.Values)
        {
            planet.NextGeneration();

            totalInfected += planet.Infected;
            totalDeaths += planet.Deaths;
        }

        UI_Overview.Instance.GenerateMutations(totalInfected);

        PlanetCanvasManager.Instance.UpdateStats();
        UI_Overview.Instance.UpdateStats(totalInfected, totalDeaths);
    }
}
