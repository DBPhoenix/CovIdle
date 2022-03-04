using System;
using UnityEngine;

public class Population
{
    private Planet _planet;
    public PopulationSegment[] Uninfected;
    private PopulationSegment[] _infected;

    public Population(Planet planet)
    {
        _planet = planet;

        Uninfected = new PopulationSegment[11];
        for (int ResistanceLevel = 0; ResistanceLevel < 11; ResistanceLevel++)
        {
            Uninfected[ResistanceLevel] = new PopulationSegment((int) (planet.Data.PopulationSize * planet.Data.ResistanceDistribution[ResistanceLevel]), ResistanceLevel / 10f);
        }

        _infected = new PopulationSegment[11];
        for (int i = 0; i < 11; i++)
        {
            _infected[i] = new PopulationSegment(0, i / 10f);
        }

        _infected[0].Size = 125;
        Uninfected[0].Size -= 125;
    }

    public double EstimateNewDeaths()
    {
        double newDeaths = 0;

        foreach (PopulationSegment infected in _infected)
        {
            newDeaths += infected.Size * Perks.DeathRate;
        }

        return newDeaths;
    }

    public double EstimateNewInfections()
    {
        double newInfections = 0;
        double infectionModifier = InfectionMultiplier();

        foreach (PopulationSegment infected in _infected)
        {
            newInfections += infected.Size;
        }

        return newInfections * infectionModifier;
    }

    public void NextVirusSpread()
    {
        double newInfections = 0;
        double infectionModifier = InfectionMultiplier();

        double[] distribution = UninfectedResistanceDistribution();

        // Calculate Total Amount of New Infections
        for (int i = 0; i < 10; i++)
        {
            PopulationSegment infected = _infected[i];

            newInfections += infected.Size * infectionModifier;

            double deaths = infected.Size * Perks.DeathRate;
            _planet.Deaths += deaths;
            infected.Size -= deaths;

            Uninfected[i + 1].Size += infected.Size * (1 - Perks.InfectedCarryOverRate);
            infected.Size = infected.Size * Perks.InfectedCarryOverRate;
        }

        // Infect New Uninfected Segments based on Distribution
        for (int i = 0; i < 11; i++)
        {
            double infected = Math.Floor(newInfections * distribution[i]);

            Uninfected[i].Size -= infected;
            _infected[i].Size += infected;
        }

        if (Perks.MutationPointsFromInfected > 1)
        {
            UI_Overview.Instance.Mutations += Math.Log(newInfections, Perks.MutationPointsFromInfected);
        }

        double totalInfected = 0;
        foreach (PopulationSegment infected in _infected)
        {
            totalInfected += infected.Size;
        }

        _planet.Infected = Math.Floor(totalInfected);
    }

    private double[] UninfectedResistanceDistribution()
    {
        double totalPopulation = 0;

        foreach (PopulationSegment uninfected in Uninfected)
        {
            totalPopulation += uninfected.Size * (1 - uninfected.NaturalResistance);
        }

        double[] distribution = new double[11];

        for (int i = 0; i < 11; i++)
        {
            PopulationSegment uninfected = Uninfected[i];
            distribution[i] = (uninfected.Size * (1 - uninfected.NaturalResistance)) / totalPopulation;
        }

        return distribution;
    }

    private double InfectionMultiplier()
    {
        float temperatureDiff = Mathf.Min(Mathf.Abs(_planet.Temperature - Perks.MinOptimalTemperature), Mathf.Abs(_planet.Temperature - Perks.MaxOptimalTemperature));
        float temperatureModifier = Mathf.Pow(1 - 0.05f, temperatureDiff / 0.25f);

        return temperatureModifier * Perks.InfectionRate * (_planet.Data.MeetingsPerInfected + Perks.MeetingsPerInfected) * (1 - (AverageResistance() * (1 - Math.Pow(0.95, Perks.NaturalResistanceModifier))));
    }

    private float AverageResistance()
    {
        double totalResistance = 0;
        double totalUninfected = 0;

        foreach (PopulationSegment uninfected in Uninfected)
        {
            totalResistance += uninfected.Size * uninfected.NaturalResistance;
            totalUninfected += uninfected.Size;
        }

        return (float) (totalResistance / totalUninfected);
    }
}

public struct PopulationSegment
{
    public double Size;
    public float NaturalResistance;

    public PopulationSegment(double size, float naturalResistance)
    {
        Size = size;
        NaturalResistance = naturalResistance;
    }
}
