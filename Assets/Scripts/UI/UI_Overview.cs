using System;
using System.Collections.Generic;
using UnityEngine;

public class UI_Overview : MonoBehaviour
{
    public static UI_Overview Instance;

    [Space]
    [SerializeField]
    private UI_Text[] _uiElements;

    public double Mutations = 0;
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
    }

/*
    private void Start()
    {
        InvokeRepeating("NextGeneration", 0, _durationBetweenGenerations);
    }

    private void Update()
    {
        IncreaseInfected(_infectedGain * Time.deltaTime);
        IncreaseDeaths(_deathsGain * Time.deltaTime);

        GenerateMutations();
    }
*/

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void UpdateStats(double infected, double deaths)
    {
        _uiByName["Infected"].SetValue(infected);
        _uiByName["Deaths"].SetValue(deaths);
        _uiByName["Mutations"].SetValue(Mutations);

        if (Perks.MinOptimalTemperature == Perks.MaxOptimalTemperature)
        {
            _uiByName["Ideal Temperature"].SetValue($"{Perks.MinOptimalTemperature}");
        }
        else
        {
            _uiByName["Ideal Temperature"].SetValue($"{Perks.MinOptimalTemperature} - {Perks.MaxOptimalTemperature}");
        }
    }

    public void GenerateMutations(double infected)
    {
        Mutations += Math.Log(infected, 10 - Perks.MutationModifier) * Time.deltaTime;
        GameManager.Instance.UpdateStats();
        PlanetCanvasManager.Instance.UpdateStats();
    }

/*
    private void IncreaseDeaths(float amount)
    {
        _infected -= amount;
        _deaths += amount;

        _uiByName["Deaths"].SetValue((int) _deaths);
    }

    private void IncreaseInfected(float amount)
    {
        _infected += amount;

        _uiByName["Infected"].SetValue((int) _infected);
    }

    private void NextGeneration()
    {
        _deathsGain = (_infected * _deathRate) / _durationBetweenGenerations;
        _infectedGain = (_infected * _meetingsPerInfected * _infectionRate) / _durationBetweenGenerations;
    }
*/
}
