using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UI_Perk), true)]
public class UI_PerkEditor : Editor
{
    public override void OnInspectorGUI()
    {
        UI_Perk perk = (UI_Perk) target;

        perk.Status = (PerkStatus) EditorGUILayout.EnumPopup("Status", perk.Status);

        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Icon");
            perk.Icon = (Sprite) EditorGUILayout.ObjectField(perk.Icon, typeof(Sprite), false);
            GUILayout.EndHorizontal();
        }

        EditorGUILayout.Space();

        GUILayout.Label("Description");
        perk.Description = EditorGUILayout.TextArea(perk.Description, GUILayout.Height(100));
        EditorStyles.textField.wordWrap = true;
    }
}
