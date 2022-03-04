using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UI_Building), true)]
public class UI_BuildingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        UI_Building building = (UI_Building) target;

        building.Status = (BuildingStatus) EditorGUILayout.EnumPopup("Status", building.Status);
        building.Cost = EditorGUILayout.IntField("Cost", (int) building.Cost);
        building.CostModifier = EditorGUILayout.DoubleField("Cost Modifier", building.CostModifier);

        EditorGUILayout.Space();

        GUILayout.Label("Description");
        building.Description = EditorGUILayout.TextArea(building.Description, GUILayout.Height(100));
        EditorStyles.textField.wordWrap = true;

        if (GUI.changed)
        {
            EditorUtility.SetDirty(building);
        }
    }
}
