using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(GUIText))]
public class DebugHUD : MonoBehaviour {
	private static Dictionary<string,System.Object> list;

    //RPAAEE change: removed tons of GetComponent calls
    private GUIText text;

	static DebugHUD(){
		list = new Dictionary<string,System.Object>();
	}

	public static void setValue(string key, System.Object value){
		list[key] = value;
	}

    //RPAAEE change: automatic boolean coloring
    public static void setValue(string key, bool value) {
        setValue(key, value ? "<color=green>True</color>" : "<color=red>False</color>");
    }

	public static void removeKey(string key){
		list.Remove(key);
	}
	
	void Start () {
		transform.position = Vector3.up;
        text = GetComponent<GUIText>();
		text.alignment = TextAlignment.Left;
        text.anchor = TextAnchor.UpperLeft;
        text.richText = true;
        text.enabled = Application.isEditor||Debug.isDebugBuild;
	}

	void LateUpdate () {
		if(Input.GetKeyDown(KeyCode.F3)){
            text.enabled = !text.enabled;
		}
		string s = "";
		foreach(string key in list.Keys){
			s+="<color=blue>"+key+"</color>: ";
			s+=list[key]+"\n";
		}
        text.text = s;
	}
}
