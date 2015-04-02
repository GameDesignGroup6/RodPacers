using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(GUIText))]
public class DebugHUD : MonoBehaviour {
	private static Dictionary<string,System.Object> list;

	static DebugHUD(){
		list = new Dictionary<string,System.Object>();
	}

	public static void setValue(string key, System.Object value){
		list[key] = value;
	}

	public static void removeKey(string key){
		list.Remove(key);
	}
	
	void Start () {
		transform.position = Vector3.up;
		GetComponent<GUIText>().alignment = TextAlignment.Left;
		GetComponent<GUIText>().anchor = TextAnchor.UpperLeft;
		GetComponent<GUIText>().richText = true;
		GetComponent<GUIText>().enabled = Application.isEditor||Debug.isDebugBuild;
	}

	void LateUpdate () {
		if(Input.GetKeyDown(KeyCode.F3)){
			GetComponent<GUIText>().enabled = !GetComponent<GUIText>().enabled;
		}
		string s = "";
		foreach(string key in list.Keys){
			s+="<color=blue>"+key+"</color>: ";
			s+=list[key]+"\n";
		}
		GetComponent<GUIText>().text = s;
	}
}
