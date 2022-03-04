using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ColdHeatOne))]
public class ColdHeatOneEditor : Editor
{
    SerializedProperty leadsToArray;

    private void OnEnable()
    {
        leadsToArray = serializedObject.FindProperty("LeadsTo");
    }

    public override void OnInspectorGUI()
    {
        ColdHeatOne perk = (ColdHeatOne) target;

        perk.Status = (PerkStatus) EditorGUILayout.EnumPopup("Status", perk.Status);
        perk.Cost = EditorGUILayout.IntField("Cost", (int) perk.Cost);

        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Icon");
            perk.Icon = (Sprite) EditorGUILayout.ObjectField(perk.Icon, typeof(Sprite), false);
            GUILayout.EndHorizontal();
        }

        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(leadsToArray);

        EditorGUILayout.Space();

        GUILayout.Label("Description");
        perk.Description = EditorGUILayout.TextArea(perk.Description, GUILayout.Height(100));
        EditorStyles.textField.wordWrap = true;

        EditorGUILayout.Space();

        GUILayout.Label("Choice Description");
        perk.ChoiceDescription = EditorGUILayout.TextArea(perk.ChoiceDescription, GUILayout.Height(100));
        EditorStyles.textField.wordWrap = true;

        if (GUI.changed)
        {
            EditorUtility.SetDirty(perk);
        }
    }
}
