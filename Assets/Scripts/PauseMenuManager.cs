using UnityEngine;
using System.Collections;

public class PauseMenuManager : MonoBehaviour {

	private bool paused = false;

	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Pause") == 1 && paused == false) {
			Application.LoadLevel (0);
//			paused = true;
//			Time.timeScale = 0f;
		}
		if (paused == true && Input.GetAxis ("Unpause") == 1) {
			paused = false;
			Time.timeScale = 1;
		}

		if (paused == true && Input.GetAxis ("Reset") == 1) {
			Application.LoadLevel (0);
		}
	}
}
