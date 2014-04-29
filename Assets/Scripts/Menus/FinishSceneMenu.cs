using UnityEngine;
using System.Collections;

public class FinishSceneMenu : MonoBehaviour {
	string restartScene;
	// Use this for initialization
	void Start () {
		restartScene = GetComponent<StartMenu> ().nextScenes [0];
		if (PlayerManager.playerCount == 1)
						restartScene = "SinglePlayer";
		else if (PlayerManager.playerCount == 2)
			restartScene = "TwoPlayer";
		else if (PlayerManager.playerCount == 3)
			restartScene = "ThreePlayer";
		else if (PlayerManager.playerCount == 4)
			restartScene = "FourPlayer";
		else
			restartScene = "SinglePlayer";
		GetComponent<StartMenu> ().nextScenes [0] = restartScene;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
