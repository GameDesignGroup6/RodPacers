using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class WireframeCameraScript : MonoBehaviour {
	public bool wireframeEnabled = true;
	void Update(){
		if(Input.GetKeyDown(KeyCode.F5)){
			wireframeEnabled = !wireframeEnabled;
		}
	}
	void OnPreRender() {
		GL.wireframe = wireframeEnabled;
	}
	void OnPostRender() {
		GL.wireframe = false;
	}
}
