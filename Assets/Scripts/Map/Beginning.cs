using UnityEngine;
using System.Collections;
// Used for Test0, the intro screen for easymap
public class Beginning : MonoBehaviour {

	void Start() {
		Cursor.visible = false;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	// Update is called once per frame
	void Update () {
		// let the song finish
		if (Time.timeSinceLevelLoad >= 40 || Input.anyKey == true) {
			Application.LoadLevel ("EasyMap");
		}
	}
}
