using UnityEngine;
using System.Collections;

public class PodPauseMenu : MonoBehaviour {
	
	public GUIText[] menuChoices;
	public Light dimmerLight;
	private int position = 0;
	private float updateIsTooFast = .25f;
	private bool paused = false;
	private float whatWouldBeDeltaTime;
	
	void Start () {
		whatWouldBeDeltaTime = Time.deltaTime;//this doesnt do anything, you realize
		menuChoices[0].color = Color.white;
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

		if (Input.GetAxis ("LeftStickVert1") > 0.5 && paused) {
			menuChoices[position].color = Color.yellow;
			position--;
			if (position < 0) {
				position = menuChoices.Length - 1;
			}
			updateIsTooFast = 0.25f;
		}
		if (Input.GetAxis ("LeftStickVert1") < -0.5f && paused) {
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
