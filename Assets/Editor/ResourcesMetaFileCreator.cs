using UnityEngine;
using UnityEditor;
using System.IO;

public class ResourcesMetaFileCreator : UnityEditor.AssetModificationProcessor {
	public static string[] OnWillSaveAssets(string[] paths){
//		foreach (string s in paths)Debug.Log ("save: "+s);
		BuildMetaFile();
		return paths;
	}
	public static void OnWillCreateAsset(string a){
//		Debug.Log ("Create: "+a);
		BuildMetaFile();
	}

	private static void BuildMetaFile(){
		string[] files = Directory.GetDirectories("Assets/Resources/Pods/");
		StreamWriter sw = new StreamWriter("Assets/Resources/Pods/podlist.txt");
		sw.Write("NULL");
		foreach(string s in files){
			char[] delimit = {'/'};
			string[] split = s.Split(delimit);
			sw.Write(":");
			sw.Write(split[split.Length-1]);
		}
		sw.Flush();
		sw.Close();
		Debug.Log("Wrote podlist");
	}
}
