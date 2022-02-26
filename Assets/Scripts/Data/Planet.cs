using UnityEngine;

public class Planet
{
    public PlanetData Data;

    public double Infected = 100;
    public double Deaths = 0;

    private Population _population;

    [HideInInspector]
    public float Temperature;

    public Planet(PlanetData data)
    {
        Data = data;

        Temperature = data.Temperature;

        _population = new Population(this);
    }

    public void NextGeneration()
    {
        _population.NextVirusSpread();
    }
}
