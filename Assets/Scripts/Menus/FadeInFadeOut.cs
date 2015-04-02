using UnityEngine;
using System.Collections;
// Used for the two title screens to load the next scene
public class FadeInFadeOut : MonoBehaviour {

	public string nextLevel;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > 5.0f || Input.anyKeyDown) {
			Application.LoadLevel (nextLevel);
		}
	}
}
