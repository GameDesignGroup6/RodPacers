using UnityEngine;
using System.Collections;

public class MenuCamera : MonoBehaviour {

	// What scenes should the menu camera disappear on
	public string[] destroyOn;
	
	private static MenuCamera instance = null;
	public static MenuCamera Instance {
		get { return instance; }
	}
	void Awake() {
		// Does the camera already exist in the scene? if so, make this one go away
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < destroyOn.Length; i++) {
			if (Application.loadedLevelName == destroyOn[i]) {
				Destroy (this.gameObject);
			}
		}
	}
}
