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
			DebugHUD.setValue("Time", Time.timeSinceLevelLoad);
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
			DebugHUD.setValue ("Finished", finished);
		}
		return finished;
	}
}
