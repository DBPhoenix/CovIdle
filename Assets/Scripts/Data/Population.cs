public class Population
{
    private Planet _planet;
    private PopulationSegment[] _segments;

    public Population(Planet planet)
    {
        _planet = planet;

        _segments = new PopulationSegment[11];
        for (int ResistanceLevel = 0; ResistanceLevel < 11; ResistanceLevel++)
        {
            _segments[ResistanceLevel] = new PopulationSegment((int) (planet.Data.PopulationSize * planet.Data.ResistanceDistribution[ResistanceLevel]), ResistanceLevel / 10f);
        }
    }

    public void NextVirusSpread()
    {
        for (int i = 10; i > -1; i++)
        {
            PopulationSegment segment = _segments[i];

            float newDeaths = segment.Size * Perks.DeathRate;

            float temperatureDiff = Mathf.Min(Mathf.Abs(_planet.Temperature - Perks.MinOptimalTemperature), Mathf.Abs(_planet.Temperature - Perks.MaxOptimalTemperature));
            float temperatureModifier = Mathf.Pow(1 - 0.05f, temperatureDiff / 0.25f);


        }
/*
        float newDeaths = Infected * _deathRate;

        float temperatureDiff = Mathf.Min(Mathf.Abs(_temperature - Perks.MinOptimalTemperature), Mathf.Abs(_temperature - Perks.MaxOptimalTemperature));
        float temperatureModifier = Mathf.Pow(1 - 0.05f, temperatureDiff / 0.25f);

        Infected += Infected * Perks.InfectionRate * temperatureModifier * Data.MeetingsPerInfected;

        Deaths += newDeaths;
        Infected -= newDeaths;
*/
    }
}

struct PopulationSegment
{
    public int Size;
    public float NaturalResistance;

    public PopulationSegment(int size, float naturalResistance)
    {
        Size = size;
        NaturalResistance = naturalResistance;
    }
}
