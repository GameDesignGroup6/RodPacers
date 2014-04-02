using UnityEngine;
using System.Collections;

public class Beginning : MonoBehaviour {

	public GameObject mainCamera, beginningCamera, engineHUDLeft, engineHUDRight;
	public GUIText debugHUD, tatooineText, boontaEveText;
	public AudioSource podSound, beginningMusic, endMusic, trackMusic;
	private bool started = false;
	public static float subtractTime;

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		started = false;
		debugHUD.enabled = false;
		tatooineText.enabled = true;
		boontaEveText.enabled = true;
		RotatableGuiItem[] metersLeft = engineHUDLeft.GetComponents<RotatableGuiItem>();
		RotatableGuiItem[] metersRight = engineHUDRight.GetComponents<RotatableGuiItem>();
		engineHUDLeft.GetComponent<EngineStatusHUD>().enabled = false;
		engineHUDRight.GetComponent<EngineStatusHUD>().enabled = false;
		for (int i = 0; i < metersLeft.Length; i++) {
			metersLeft[i].enabled = false;
		}
		for (int i = 0; i < metersRight.Length; i++) {
			metersRight[i].enabled = false;
		}
		podSound.playOnAwake = false;
		beginningMusic.Play ();
		trackMusic.playOnAwake = false;
		mainCamera.camera.enabled = false;
		mainCamera.GetComponent<AudioListener>().enabled = false;
		beginningCamera.camera.enabled = true;
		beginningCamera.audio.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
			if (Time.timeSinceLevelLoad >= 40 || Input.anyKey == true) {
				beginningMusic.Stop ();
				tatooineText.enabled = false;
				boontaEveText.enabled = false;
				debugHUD.enabled = true;
				engineHUDLeft.GetComponent<EngineStatusHUD>().enabled = true;
				engineHUDRight.GetComponent<EngineStatusHUD>().enabled = true;
				RotatableGuiItem[] metersLeft = engineHUDLeft.GetComponents<RotatableGuiItem>();
				RotatableGuiItem[] metersRight = engineHUDRight.GetComponents<RotatableGuiItem>();
				for (int i = 0; i < metersLeft.Length; i++) {
					metersRight[i].enabled = true;
				}
				for (int i = 0; i < metersRight.Length; i++) {
					metersLeft[i].enabled = true;
				}
				mainCamera.camera.enabled = true;
				mainCamera.GetComponent<AudioListener>().enabled = true;
				Destroy (beginningCamera);
				subtractTime = Time.timeSinceLevelLoad;
				trackMusic.Play ();
				podSound.Play ();
				started = true;
			}
		}
	}
}
