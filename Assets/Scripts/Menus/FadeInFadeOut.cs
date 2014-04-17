using UnityEngine;
using System.Collections;

public class FadeInFadeOut : MonoBehaviour {

	public string nextLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > 5.0f) {
			Application.LoadLevel (nextLevel);
		}
	}
}
