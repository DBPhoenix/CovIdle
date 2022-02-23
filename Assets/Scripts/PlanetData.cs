using UnityEngine;

[CreateAssetMenu(fileName = "Planet", menuName = "ScriptableObjects/Planet")]
public class PlanetData : ScriptableObject
{
    public string Name;
    public int PopulationSize;
    public Sprite Map;

    [Space]
    public float Temperature;
    public float MeetingsPerInfected;

    [Space]
    public float[] ResistanceDistribution = new float[11];
}
