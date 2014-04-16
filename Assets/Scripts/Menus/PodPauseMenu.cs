using UnityEngine;
using System.Collections;

public class PodPauseMenu : MonoBehaviour {
	
	public GUIText[] menuChoices;
	private int position = 0;
	private float updateIsTooFast = .25f;
	private bool paused = false;
	private float whatWouldBeDeltaTime;
	
	void Start () {
		whatWouldBeDeltaTime = Time.deltaTime;
		menuChoices[0].color = Color.white;
		for (int i = 0; i < menuChoices.Length; i++) {
			menuChoices[i].enabled = false;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		DebugHUD.setValue ("position", position);
		DebugHUD.setValue ("Throttle", Input.GetAxis ("Throttle1"));
		DebugHUD.setValue ("Pause", Input.GetAxis ("Pause"));
		if (updateIsTooFast > 0) {
			updateIsTooFast = updateIsTooFast - whatWouldBeDeltaTime;
			return;
		}

		if (Input.GetAxis ("Pause") == 1) {
			if (!paused) {
				pause();
			}
		}

		if (Input.GetAxis ("LeftStickVert") > 0.025 && paused) {
			menuChoices[position].color = Color.yellow;
			position--;
			if (position < 0) {
				position = menuChoices.Length - 1;
			}
			updateIsTooFast = 0.25f;
		}
		if (Input.GetAxis ("LeftStickVert") < -0.025f && paused) {
			menuChoices[position].color = Color.yellow;
			position = (position + 1)%menuChoices.Length;
			updateIsTooFast = 0.25f;
		}
		
		menuChoices[position].color = Color.white;
		
		if (Input.GetAxis ("LeftStickHoriz") > 0.025f && paused) {
			if (position == 0) {
				DebugHUD.setValue ("unpaused", true);
				unpause ();
			}
			else if (position == 1) {
				unpause ();
				Application.LoadLevel (Application.loadedLevel);
			}
			else if (position == 2) {
				unpause ();
				Application.Quit();
			}
		}
	}

	public void pause() {
		Time.timeScale = 0;
		AudioListener.pause = true;
		for (int i = 0; i < menuChoices.Length; i++) {
			menuChoices[i].enabled = true;
		}
		paused = true;
	}

	public void unpause() {
		AudioListener.pause = false;
		for (int i = 0; i < menuChoices.Length; i++) {
			menuChoices[i].enabled = false;
		}
		Time.timeScale = 1;
		paused = false;
	}
}
