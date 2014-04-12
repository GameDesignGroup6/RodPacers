using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public GUIText[] menuChoices;
	public string[] nextScenes;
	private int position = 0;
	private float updateIsTooFast = .25f;

	void Start () {
		menuChoices[0].color = Color.white;
	}

	// Update is called once per frame
	void Update () {
		if (updateIsTooFast > 0) {
			updateIsTooFast = updateIsTooFast - Time.deltaTime;
			return;
		}

		if (Input.GetAxis ("LeftStickVert") > 0.025f) {
			menuChoices[position].color = Color.yellow;
			position--;
			if (position < 0) {
				position = 2;
			}
			updateIsTooFast = 0.25f;
		}
		if (Input.GetAxis ("LeftStickVert") < -0.025f) {
			menuChoices[position].color = Color.yellow;
			position = (position + 1)%menuChoices.Length;
			updateIsTooFast = 0.25f;
		}

		menuChoices[position].color = Color.white;

		if (Input.GetAxis ("Throttle1") > 0) {
			if (nextScenes[position] == "Quit") {
				Application.Quit ();
			}
			else {
				Application.LoadLevel (nextScenes[position]);
			}
		}
	}
}
