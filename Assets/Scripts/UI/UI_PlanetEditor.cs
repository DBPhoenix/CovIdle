using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UI_Planet))]
public class UI_PlanetEditor : Editor
{
    public override void OnInspectorGUI()
    {
        UI_Planet planet = (UI_Planet) target;

        planet.PlanetData = (PlanetData) EditorGUILayout.ObjectField("Planet", planet.PlanetData, typeof(PlanetData), false);
        planet.Active = EditorGUILayout.Toggle("Active", planet.Active);
    }
}
