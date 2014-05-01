using UnityEngine;
using System.Collections;
// Whenever there is no camera, display Loading...
public class LoadingScreen : MonoBehaviour {
	public Texture2D background;
	public GUIStyle style;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}

	void OnGUI(){
		if(Camera.allCameras.Length!=0)return;
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),background);
		Rect rect = new Rect(Screen.width-400,Screen.height-200,400,200);
		GUI.Label(rect,"Loading...",style);
	}
}
