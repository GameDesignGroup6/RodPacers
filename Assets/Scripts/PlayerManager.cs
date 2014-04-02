using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private static int numLaps = 0;
	private int place;
	private static bool finished = false;

	// Use this for initialization
	void Start () {
		finished = false;
		numLaps = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!finished) {
<<<<<<< HEAD
			DebugHUD.setValue("Time", Time.timeSinceLevelLoad - Beginning.subtractTime);
=======
			DebugHUD.setValue("Time", Time.time);
			//DebugHUD.setValue ("PlayingEndMusic", 0);
		}
		else {
			PlayEndingMusic ();
			//DebugHUD.setValue ("PlayingEndMusic", 1);
>>>>>>> 8b964c1d497f2913bd9a7091756604a5ee21b852
		}
	}

	public static void AddLap(int inOrder) {
		if (inOrder >= 0.75*numLaps*88) {
			numLaps++;
			DebugHUD.setValue ("Lap", numLaps);
		}
	}

	public static bool Finish() {
		if (numLaps == MapManager.maxLaps) {
			finished = true;
			TestEngineController.acceptUserInputOn = false;
			DebugHUD.setValue ("Finished", finished);
		}
		return finished;
	}
<<<<<<< HEAD
=======

	public void PlayEndingMusic() {
		gameObject.GetComponent<AudioSource>().Play();
	}
>>>>>>> 8b964c1d497f2913bd9a7091756604a5ee21b852
}
