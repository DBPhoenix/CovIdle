using UnityEngine;

public class Planet
{
    public PlanetData Data;

    public double Infected = 125;
    public double Deaths = 0;

    public Population Population;

    [HideInInspector]
    public float Temperature;

    public Planet(PlanetData data)
    {
        Data = data;

        Temperature = data.Temperature;

        Population = new Population(this);
    }

    public void NextGeneration()
    {
        Population.NextVirusSpread();
    }

    public double EstimateNewDeaths()
    {
        return Population.EstimateNewDeaths();
    }

    public double EstimateNewInfections()
    {
        return Population.EstimateNewInfections();
    }
}
