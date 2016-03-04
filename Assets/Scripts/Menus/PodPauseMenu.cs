using UnityEngine;
using System.Collections;

public class PodPauseMenu : MonoBehaviour {

	// The options to choose from
	public GUIText[] menuChoices;

	// The maps have two suns, turn off one when it's paused
	public Light dimmerLight;

	// The current position in the menu
	private int position = 0;

	// Make it so it only changes every quarter second if you hold down the button
	private float updateIsTooFast = .25f;

	// If the game is paused
	private bool paused = false;

	// Reference for when timeScale = 0
	private float whatWouldBeDeltaTime;
	
	void Start () {
		Cursor.visible = false;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		whatWouldBeDeltaTime = Time.deltaTime;//this doesnt do anything, you realize // shuddup
		menuChoices[0].color = Color.white;

		// Don't see the pause menu at the beginning
		for (int i = 0; i < menuChoices.Length; i++) {
			menuChoices[i].enabled = false;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (updateIsTooFast > 0) {
			updateIsTooFast = updateIsTooFast - whatWouldBeDeltaTime;
			return;
		}

		if (Input.GetButtonDown ("Pause")) {
			if (!paused) {
				pause();
			}else{
				unpause();
			}
		}

		if (Input.GetAxis ("LeftStickVert1") > 0.1f && paused) {
			menuChoices[position].color = Color.yellow;
			position--;
			if (position < 0) {
				position = menuChoices.Length - 1;
			}
			updateIsTooFast = 0.25f;
		}
		if (Input.GetAxis ("LeftStickVert1") < -0.1f && paused) {
			menuChoices[position].color = Color.yellow;
			position = (position + 1)%menuChoices.Length;
			updateIsTooFast = 0.25f;
		}
		
		menuChoices[position].color = Color.white;
		
		if (Input.GetButtonDown ("Throttle1") && paused) {
			if (position == 0) {
				unpause ();
			}
			else if (position == 1) {
				unpause ();
				Application.LoadLevel (Application.loadedLevel);
			}
			else if (position == 2) {
				unpause ();
				Application.LoadLevel("StartScreen");
			}
		}
	}

	/**
	 * Stops time and makes the pause menu appear
	 */
	public void pause() {
		Time.timeScale = 0;
		Input.ResetInputAxes();
		dimmerLight.enabled = false;
		AudioListener.pause = true;
		for (int i = 0; i < menuChoices.Length; i++) {
			menuChoices[i].enabled = true;
		}
		paused = true;
	}

	/**
	 * Restarts time and makes the pause menu disappear
	 */
	public void unpause() {
		dimmerLight.enabled = true;
		AudioListener.pause = false;
		for (int i = 0; i < menuChoices.Length; i++) {
			menuChoices[i].enabled = false;
		}
		Time.timeScale = 1;
		paused = false;
		Input.ResetInputAxes();
	}
}
