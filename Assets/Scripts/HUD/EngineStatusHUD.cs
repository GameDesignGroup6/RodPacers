using UnityEngine;
using System.Collections;

public class EngineStatusHUD : MonoBehaviour {
	public RotatableGuiItem background;
	public RotatableGuiItem greenMeter;
	public RotatableGuiItem redMeter;
	public RotatableGuiItem blueMeter;
	public RigidbodyInfo infoToTrack;
	public EngineThruster engineToTrack;
	public EngineHealth health;
	public bool inverted;
	private int timer = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float healthPercent = health.Health/health.maxHealth;
		blueMeter.angle = 180f+infoToTrack.Velocity*3f;//div 100, times 360; ...but just 3 looks better
		greenMeter.angle = 180f+(engineToTrack.thrust/(engineToTrack.DefaultThrust*1.1f))*180f;
		redMeter.angle = 180f+healthPercent*180f;

		if(healthPercent<=0.2f){
			timer++;
			if(timer==30){
				redMeter.color.a = 0f;
			}else if(timer>=60){
				redMeter.color.a = 1f;
				timer=0;
			}
		}



		if(blueMeter.angle>360f)blueMeter.angle=360f;
		if(redMeter.angle>360f)redMeter.angle=360f;
		if(greenMeter.angle>360f)greenMeter.angle=360f;


		if(inverted){
			greenMeter.angle = -greenMeter.angle-180f;
			redMeter.angle = -redMeter.angle-180f;
			blueMeter.angle = -blueMeter.angle-180f;
		}
	}
	void OnGUI(){
		background.render();
		redMeter.render();
		greenMeter.render();
		blueMeter.render();
	}
}
