using UnityEngine;

public class Planet
{
    public PlanetData Data;

    public float Infected = 100;
    public float Deaths = 0;
    public float Mutations = 0;

    private float _deathRate = 0.2f;
    private float _mutationRate = 0.2f;
    private float _infectedRate = 0.2f;

    public Planet(PlanetData data)
    {
        Data = data;
    }

    public void NextGeneration()
    {
        float newDeaths = Infected * _deathRate;

        Infected += Infected * _infectedRate;
        Deaths += newDeaths;
        Mutations += Infected * _mutationRate;

        Infected -= newDeaths;
    }
}
