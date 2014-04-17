using UnityEngine;
using System.Collections;

public class MenuCamera : MonoBehaviour {
	public string[] destroyOn;
	private static MenuCamera instance = null;
	public static MenuCamera Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	// Use this for initialization
	void Start () {

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
