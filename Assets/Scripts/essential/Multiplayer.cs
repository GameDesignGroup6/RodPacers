using UnityEngine;
using System.Collections;
// we didn't have the heart to delete it
public class Multiplayer : MonoBehaviour {

	public int numPlayers = 1;
//	public Camera[] cameras;
//	public RotatableGuiItem[] allTheEngineMeters;
//	public Camera miniMap;

	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.showCursor = false;
//		Application.LoadLevelAdditive ("SinglePlayer");
//		miniMap.enabled = false;
//		for (int i = numPlayers; i < cameras.Length; i++) {
//			cameras[i].enabled = false;
//		}
//		for (int i = numPlayers * 2; i < allTheEngineMeters.Length; i++) {
//			RotatableGuiItem[] rotatableGUIs = allTheEngineMeters[i].GetComponents<RotatableGuiItem>();
//			for (int j = 0; j < rotatableGUIs.Length; j++) {
//				rotatableGUIs[j].enabled = false;
//			}
//		}
//		if (numPlayers == 1) {
//			cameras[0].rect = new Rect(0,0,1.0f,1.0f);
//			miniMap.enabled = true;
//			miniMap.rect = new Rect(.7f, .7f, .3f, .31f);
//		}
//		if (numPlayers == 2) {
//			cameras[0].rect = new Rect(0,.5f,1.0f,.5f);
//			cameras[1].rect = new Rect(0,0,1.0f,.5f);
//			miniMap.enabled = true;
//		}
//		if (numPlayers == 3) {
//			cameras[0].rect = new Rect(0.0f,.5f,.5f,.5f);
//			cameras[1].rect = new Rect(.5f,.5f,.5f,.5f);
//			cameras[2].rect = new Rect(0.0f,0.0f,.5f,.5f);
//			miniMap.enabled = true;
//			miniMap.rect = new Rect(.5f,0.0f,.5f,.5f);
//		}
//		if (numPlayers == 4) {
//			cameras[0].rect = new Rect(0.0f,.5f,.5f,.5f);
//			cameras[1].rect = new Rect(.5f,.5f,.5f,.5f);
//			cameras[2].rect = new Rect(0.0f,0.0f,.5f,.5f);
//			cameras[3].rect = new Rect(.5f,0.0f,.5f,.5f);
//			miniMap.enabled = true;
//		}
	}
}
