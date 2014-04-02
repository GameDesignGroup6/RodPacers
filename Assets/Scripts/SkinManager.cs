using UnityEngine;
using System.Collections;

public static class SkinManager {
	public static string[] SkinList{
		get{
			return list;
		}
	}

	private static string[] list;
	static SkinManager(){
		TextAsset ta = Resources.Load<TextAsset>("Pods/podlist");
		if(ta==null){
			Debug.LogError("podlist could not be loaded!");
		}

		char[] delim = {':'};
		list = ta.text.Split(delim);
	}
}
