using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public GUIText[] menuChoices;
	public string[] nextScenes;
	public string previousScene;
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
//			string s = menuChoices[position].text;
//			menuChoices[position].text = s + ">";
			if (position < 0) {
				position = menuChoices.Length - 1;
			}
			updateIsTooFast = 0.25f;
		}
		if (Input.GetAxis ("LeftStickVert") < -0.025f) {
			menuChoices[position].color = Color.yellow;
			position = (position + 1)%menuChoices.Length;
//			string s = menuChoices[position].text;
//			menuChoices[position].text = s + ">";
			updateIsTooFast = 0.25f;
		}

		menuChoices[position].color = Color.white;

		if (Input.GetAxis ("LeftStickHoriz") > 0.025f) {
			Application.LoadLevel (nextScenes[position]);
		}

		if (Input.GetAxis ("LeftStickHoriz") < -0.025f) {
			if (previousScene == "Quit") {
				Application.Quit ();
			}
			else {
				Application.LoadLevel(previousScene);
			}
		}
	}
}
