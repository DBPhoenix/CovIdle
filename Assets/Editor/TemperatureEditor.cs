using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Temperature))]
public class TemperatureEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Temperature building = (Temperature) target;

        building.Status = (BuildingStatus) EditorGUILayout.EnumPopup("Status", building.Status);
        building.Cost = EditorGUILayout.IntField("Cost", (int) building.Cost);

        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Ice Age");
            building.IceAge = (Sprite) EditorGUILayout.ObjectField(building.IceAge, typeof(Sprite), false);
            GUILayout.EndHorizontal();
        }

        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Global Warming");
            building.GlobalWarming = (Sprite) EditorGUILayout.ObjectField(building.GlobalWarming, typeof(Sprite), false);
            GUILayout.EndHorizontal();
        }

        EditorGUILayout.Space();

        GUILayout.Label("Description");
        building.Description = EditorGUILayout.TextArea(building.Description, GUILayout.Height(100));
        EditorStyles.textField.wordWrap = true;
    }
}
