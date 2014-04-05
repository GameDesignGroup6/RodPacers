using UnityEngine;
using System.Collections;

public class Multiplayer : MonoBehaviour {

	public int numPlayers = 1;
	public Camera[] cameras;
	public RotatableGuiItem[] allTheEngineMeters;
	public Camera miniMap;

	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.showCursor = false;
		miniMap.enabled = false;
		for (int i = numPlayers; i < cameras.Length; i++) {
			cameras[i].enabled = false;
		}
		for (int i = numPlayers * 2; i < allTheEngineMeters.Length; i++) {
			RotatableGuiItem[] rotatableGUIs = allTheEngineMeters[i].GetComponents<RotatableGuiItem>();
			for (int j = 0; j < rotatableGUIs.Length; j++) {
				rotatableGUIs[j].enabled = false;
			}
		}
		if (numPlayers == 1) {
			cameras[0].pixelRect = new Rect(0,0,1000f,1000f);
			miniMap.enabled = true;
			miniMap.pixelRect = new Rect(574.5f,574.5f,191.5f,178f);
		}
		if (numPlayers == 2) {
			cameras[0].pixelRect = new Rect(0,356f,1000f,356f);
			cameras[1].pixelRect = new Rect(0,0,1000f,356f);
			miniMap.enabled = true;
		}
		if (numPlayers == 3) {
			cameras[0].pixelRect = new Rect(0.0f,356f,383f,356f);
			cameras[1].pixelRect = new Rect(383f,356f,383f,356f);
			cameras[2].pixelRect = new Rect(0.0f,0.0f,383f,356f);
			miniMap.enabled = true;
			miniMap.pixelRect = new Rect(383f,0.0f,383f,356f);
		}
		if (numPlayers == 4) {
			cameras[0].pixelRect = new Rect(0.0f,356f,383f,356f);
			cameras[1].pixelRect = new Rect(383f,356f,383f,356f);
			cameras[2].pixelRect = new Rect(0.0f,0.0f,383f,356);
			cameras[3].pixelRect = new Rect(383f,0.0f,383f,356f);
			miniMap.enabled = true;
		}
	}
}
