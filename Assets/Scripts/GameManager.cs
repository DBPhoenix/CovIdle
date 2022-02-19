using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int _durationBetweenGenerations;
    [SerializeField]
    int _meetingsPerInfected;

    [Header("Stats")]
    [SerializeField]
    float _infected = 1;
    [SerializeField]
    float _deaths = 0;
    [SerializeField]
    float _mutations = 0;

    [Header("Rates")]
    [SerializeField, Range(0f, 1f)]
    float _deathRate;
    [SerializeField, Range(0f, 1f)]
    float _infectionRate;

    [Space]
    [SerializeField]
    UI_Text[] _uiElements;

    float _deathsGain = 0;
    float _infectedGain = 0;

    Dictionary<string, UI_Text> _uiByName = new Dictionary<string, UI_Text>();

    void Awake()
    {
        foreach (UI_Text ui in _uiElements)
        {
            _uiByName.Add(ui.gameObject.name, ui);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NextGeneration", 0, _durationBetweenGenerations);
    }

    void Update()
    {
        IncreaseInfected(_infectedGain * Time.deltaTime);
        IncreaseDeaths(_deathsGain * Time.deltaTime);

        GenerateMutations();
    }

    void GenerateMutations()
    {
        _mutations += Mathf.Log(_infected) * Time.deltaTime;

        _uiByName["Mutations"].SetValue(((int) _mutations).ToString());
    }

    void IncreaseDeaths(float amount)
    {
        _infected -= amount;
        _deaths += amount;

        _uiByName["Deaths"].SetValue(((int) _deaths).ToString());
    }

    void IncreaseInfected(float amount)
    {
        _infected += amount;

        _uiByName["Infected"].SetValue(((int) _infected).ToString());
    }

    void NextGeneration()
    {
        _deathsGain = (_infected * _deathRate) / _durationBetweenGenerations;
        _infectedGain = (_infected * _meetingsPerInfected * _infectionRate) / _durationBetweenGenerations;
    }
}
