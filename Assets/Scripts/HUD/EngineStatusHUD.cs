using UnityEngine;
using System.Collections;

public class EngineStatusHUD : MonoBehaviour {
	public RotatableGuiItem background;
	public RotatableGuiItem greenMeter;
	public RotatableGuiItem redMeter;
	public RigidbodyInfo infoToTrack;
	public EngineThruster engineToTrack;
	public bool inverted;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		greenMeter.angle = 180f+infoToTrack.Velocity*3.6f;//div 100, times 360;
		redMeter.angle = 180f+(engineToTrack.thrust/(engineToTrack.DefaultThrust*1.1f))*180f;

		if(inverted){
			greenMeter.angle = -greenMeter.angle-180f;
			redMeter.angle = -redMeter.angle-180f;
		}
	}
	void OnGUI(){
		background.render();
		redMeter.render();
		greenMeter.render();
	}
}
