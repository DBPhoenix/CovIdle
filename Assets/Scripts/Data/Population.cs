using System;
using UnityEngine;

public class Population
{
    private Planet _planet;
    private PopulationSegment[] _uninfected;
    private PopulationSegment[] _infected;

    public Population(Planet planet)
    {
        _planet = planet;

        _uninfected = new PopulationSegment[11];
        for (int ResistanceLevel = 0; ResistanceLevel < 11; ResistanceLevel++)
        {
            _uninfected[ResistanceLevel] = new PopulationSegment((int) (planet.Data.PopulationSize * planet.Data.ResistanceDistribution[ResistanceLevel]), ResistanceLevel / 10f);
        }

        _infected = new PopulationSegment[11];
        for (int i = 0; i < 11; i++)
        {
            _infected[i] = new PopulationSegment(0, i / 10f);
        }

        _infected[0].Size = 100;
        _uninfected[0].Size -= 100;
    }

    public void NextVirusSpread()
    {
        double newInfections = 0;
        float infectionModifier = InfectionMultiplier();

        double[] distribution = UninfectedResistanceDistribution();

        Debug.Log($"Infection Modifier: {infectionModifier}");

        // Calculate Total Amount of New Infections
        for (int i = 0; i < 10; i++)
        {
            PopulationSegment infected = _infected[i];

            newInfections += infected.Size * infectionModifier;
            double deaths = infected.Size * Perks.DeathRate;

            _planet.Deaths += deaths;

            _uninfected[i + 1].Size += infected.Size - deaths;
            infected.Size = infected.Size * Perks.InfectedCarryOverRate;
        }

        // Infect New Uninfected Segments based on Distribution
        for (int i = 0; i < 11; i++)
        {
            PopulationSegment uninfected = _uninfected[i];

            double infected = Math.Floor(newInfections * distribution[i]);

            uninfected.Size -= infected;
            _infected[i].Size += infected;
        }

        _planet.Infected = Math.Floor(newInfections);
    }

    private double[] UninfectedResistanceDistribution()
    {
        double totalPopulation = 0;

        foreach (PopulationSegment uninfected in _uninfected)
        {
            totalPopulation += uninfected.Size * (1 - uninfected.NaturalResistance);
        }

        double[] distribution = new double[11];

        for (int i = 0; i < 11; i++)
        {
            PopulationSegment uninfected = _uninfected[i];
            distribution[i] = (uninfected.Size * (1 - uninfected.NaturalResistance)) / totalPopulation;
        }

        return distribution;
    }

    private float InfectionMultiplier()
    {
        float temperatureDiff = Mathf.Min(Mathf.Abs(_planet.Temperature - Perks.MinOptimalTemperature), Mathf.Abs(_planet.Temperature - Perks.MaxOptimalTemperature));
        float temperatureModifier = Mathf.Pow(1 - 0.05f, temperatureDiff / 0.25f);

        Debug.Log($"Temperature Modifier: {temperatureModifier}");

        return temperatureModifier * Perks.InfectionRate * Perks.MeetingsPerInfected * AverageResistance();
    }

    private float AverageResistance()
    {
        double totalResistance = 0;
        double totalUninfected = 0;

        foreach (PopulationSegment uninfected in _uninfected)
        {
            totalResistance += uninfected.Size * uninfected.NaturalResistance;
            totalUninfected += uninfected.Size;
        }

        Debug.Log($"Total Resistance: {totalResistance}");
        Debug.Log($"Total Uninfected: {totalUninfected}");
        Debug.Log($"Average Resistance: {totalResistance / totalUninfected}");

        return (float) (totalResistance / totalUninfected);
    }
}

struct PopulationSegment
{
    public double Size;
    public float NaturalResistance;

    public PopulationSegment(double size, float naturalResistance)
    {
        Size = size;
        NaturalResistance = naturalResistance;
    }
}
