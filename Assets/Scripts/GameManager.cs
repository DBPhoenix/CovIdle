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

        PlanetCanvasManager.Instance.Open(Planets["Earth"]);

        DisplayTutorial();
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

    public double GetTotalInfected()
    {
        _totalInfected = 0;

        foreach (Planet planet in Planets.Values)
        {
            _totalInfected += planet.Infected;
        }

        return _totalInfected;
    }

    public void UniverseTutorial()
    {
        UI_Death.Instance.Display(new string[] {
            "Welcome to the galaxy. As you've made quite some progress on Earth, I thought it was about time to show you the rest of the galaxy.",
            "You can open a planet by clicking on it. Once you've conquered all of the planets in the galaxy, you'll receive your well earned rewards and become the Grim Reaper.",
            "Take your time, there's no need to hurry. Take care, it'll probably be a while, before we see each other again..."
        });
    }

    public void UpdateStats()
    {
        double totalDeaths = 0;

        foreach (Planet planet in Planets.Values)
        {
            totalDeaths += planet.Deaths;
        }

        PlanetCanvasManager.Instance.UpdateStats();
        UI_Overview.Instance.UpdateStats(GetTotalInfected(), totalDeaths);
    }

    private void DisplayTutorial()
    {
        UI_Death.Instance.Display(new string[] {
            "Welcome to CovIdle!\nI am Death the Grim Reaper. And I'll teach you to kill all of humanity with this new brilliant weapon, Covid-19!",
            "Covid-19 will automatically evolve over time giving you Mutation Points. You - the Grim Reaper Apprentice - are tasked to manage Covid-19.",
            "On this screen you can see all the information you're able to gather from Covid-19. Use this information to develop Covid-19 and hopefully eradicate humanity.",
            "If you ever get stuck, press escape and you'll return to this screen. Now let's get started, try opening the Perk Tree!"
        });
    }
}
