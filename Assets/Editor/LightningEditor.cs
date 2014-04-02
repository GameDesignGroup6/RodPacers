using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(P2PLightning))]
[CanEditMultipleObjects]
public class LightningEditor : Editor {
	private bool optionsExpanded = false;
	private bool vectorDrawing = true;
	private GUIContent button = new GUIContent("Draw in scene","Draw in scene");

	public override void OnInspectorGUI () {
		serializedObject.Update();
		P2PLightning tar = (P2PLightning)target;
		EditorGUILayout.PropertyField(serializedObject.FindProperty("numPoints"),true);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("curve"),true);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("targetMode"),true);
		if(tar.targetMode==P2PLightning.TargetMode.Point){
			EditorGUILayout.PropertyField(serializedObject.FindProperty("targetPoint"),true);
		}else{
			EditorGUILayout.PropertyField(serializedObject.FindProperty("targetTransform"),true);
		}
		optionsExpanded = EditorGUILayout.Foldout(optionsExpanded,"Editor Options");
		if(optionsExpanded){
			EditorGUI.indentLevel++;
			EditorGUILayout.HelpBox("These options are not saved and are only for use in the editor.  ",MessageType.Info);
			vectorDrawing = EditorGUILayout.Foldout(vectorDrawing,"Debug Vector Drawing");
			if(vectorDrawing){
				EditorGUI.indentLevel++;
				tar.r = EditorGUILayout.Toggle("Horizontal (red)",tar.r);
				tar.b = EditorGUILayout.Toggle("Vertical (blue)",tar.b);
				tar.g = EditorGUILayout.Toggle("Combined (green)",tar.g);
				EditorGUI.indentLevel--;
			}
			if(GUILayout.Button(button)){
				tar.SendMessage("Start");
				tar.SendMessage("UpdateRenderer");
			}
			EditorGUI.indentLevel--;
		}
		serializedObject.ApplyModifiedProperties();
	}
}
