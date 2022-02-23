using UnityEngine;

public class Planet
{
    public PlanetData Data;

    public float Infected = 100;
    public float Deaths = 0;

    private float _deathRate = 0.05f;

    [HideInInspector]
    public float Temperature;

    public Planet(PlanetData data)
    {
        Data = data;

        Temperature = data.Temperature;
    }

    public void NextGeneration()
    {
        float newDeaths = Infected * _deathRate;

        float temperatureDiff = Mathf.Min(Mathf.Abs(_temperature - Perks.MinOptimalTemperature), Mathf.Abs(_temperature - Perks.MaxOptimalTemperature));
        float temperatureModifier = Mathf.Pow(1 - 0.05f, temperatureDiff / 0.25f);

        Infected += Infected * Perks.InfectionRate * temperatureModifier * Data.MeetingsPerInfected;

        Deaths += newDeaths;
        Infected -= newDeaths;
    }
}
