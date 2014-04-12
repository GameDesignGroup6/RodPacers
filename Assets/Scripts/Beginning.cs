using UnityEngine;
using System.Collections;

public class Beginning : MonoBehaviour {

	void Start() {
		Screen.showCursor = false;
	}

	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad >= 40 || Input.anyKey == true) {
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}
}
