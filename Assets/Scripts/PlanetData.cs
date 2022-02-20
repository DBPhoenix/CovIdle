using UnityEngine;

[CreateAssetMenu(fileName = "Planet", menuName = "ScriptableObjects/Planet")]
public class PlanetData : ScriptableObject
{
    public string Name;

    [HideInInspector]
    public float Deaths;
    [HideInInspector]
    public float Infected;
}
