using UnityEngine;
using System.Collections;

public class EngineStatusHUD : MonoBehaviour {
	public RotatableGuiItem greenMeter;
	public RotatableGuiItem redMeter;
	public RigidbodyInfo infoToTrack;
	public EngineThruster engineToTrack;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		greenMeter.angle = 180f+infoToTrack.Velocity*3.6f;//div 100, times 360;
		redMeter.angle = 180f+(engineToTrack.thrust/engineToTrack.DefaultThrust)+90f;
	}
}
