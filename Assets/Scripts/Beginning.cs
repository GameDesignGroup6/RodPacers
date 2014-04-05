using UnityEngine;
using System.Collections;

public class Beginning : MonoBehaviour {

	public GameObject mainCamera1, mainCamera2, miniMap, beginningCamera, engineHUDLeft1, engineHUDRight1, engineHUDLeft2, engineHUDRight2;
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
		RotatableGuiItem[] metersLeft1 = engineHUDLeft1.GetComponents<RotatableGuiItem>();
		RotatableGuiItem[] metersRight1 = engineHUDRight1.GetComponents<RotatableGuiItem>();
		engineHUDLeft1.GetComponent<EngineStatusHUD>().enabled = false;
		engineHUDRight1.GetComponent<EngineStatusHUD>().enabled = false;
		RotatableGuiItem[] metersLeft2 = engineHUDLeft2.GetComponents<RotatableGuiItem>();
		RotatableGuiItem[] metersRight2 = engineHUDRight2.GetComponents<RotatableGuiItem>();
		engineHUDLeft2.GetComponent<EngineStatusHUD>().enabled = false;
		engineHUDRight2.GetComponent<EngineStatusHUD>().enabled = false;
		for (int i = 0; i < metersLeft1.Length; i++) {
			metersLeft1[i].enabled = false;
			metersLeft2[i].enabled = false;
		}
		for (int i = 0; i < metersRight2.Length; i++) {
			metersRight1[i].enabled = false;
			metersRight2[i].enabled = false;
		}
		podSound.playOnAwake = false;
		beginningMusic.Play ();
		trackMusic.playOnAwake = false;
		mainCamera1.camera.enabled = false;
		mainCamera1.GetComponent<AudioListener>().enabled = false;
		mainCamera2.camera.enabled = false;
		mainCamera2.GetComponent<AudioListener>().enabled = false;
		miniMap.camera.enabled = false;
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
				engineHUDLeft1.GetComponent<EngineStatusHUD>().enabled = true;
				engineHUDRight1.GetComponent<EngineStatusHUD>().enabled = true;
				RotatableGuiItem[] metersLeft1 = engineHUDLeft1.GetComponents<RotatableGuiItem>();
				RotatableGuiItem[] metersRight1 = engineHUDRight1.GetComponents<RotatableGuiItem>();
				engineHUDLeft2.GetComponent<EngineStatusHUD>().enabled = true;
				engineHUDRight2.GetComponent<EngineStatusHUD>().enabled = true;
				RotatableGuiItem[] metersLeft2 = engineHUDLeft2.GetComponents<RotatableGuiItem>();
				RotatableGuiItem[] metersRight2 = engineHUDRight2.GetComponents<RotatableGuiItem>();
				for (int i = 0; i < metersLeft1.Length; i++) {
					metersLeft1[i].enabled = true;
					metersLeft2[i].enabled = true;
				}
				for (int i = 0; i < metersRight2.Length; i++) {
					metersRight1[i].enabled = true;
					metersRight2[i].enabled = true;
				}
				mainCamera1.camera.enabled = true;
				mainCamera1.GetComponent<AudioListener>().enabled = true;
				mainCamera2.camera.enabled = true;
				mainCamera2.GetComponent<AudioListener>().enabled = true;
				miniMap.camera.enabled = true;
				Destroy (beginningCamera);
				subtractTime = Time.timeSinceLevelLoad;
				trackMusic.Play ();
				podSound.Play ();
				started = true;
			}
		}
	}
}
