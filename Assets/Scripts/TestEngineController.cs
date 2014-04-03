using UnityEngine;
using System.Collections;

public class TestEngineController : MonoBehaviour {
	public Rigidbody leftEngine,rightEngine, bothEngines, pod;
	public EngineThruster leftThruster,rightThruster;
	public bool acceptUserInput = true;
	public static bool acceptUserInputOn;
	public float podForce = 20f;
	public float turningForce = 20f;
	public float turningTorque = 50f;
	public float turningThrust = 10f;
	public float strafingForce = 5.0f;

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		acceptUserInputOn = acceptUserInput;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!acceptUserInputOn)
			acceptUserInput = false;
		if(Input.GetKeyDown(KeyCode.G)){
			acceptUserInput = true;
		}


		if(!acceptUserInput){Input.ResetInputAxes();}
		float leftTrigger = Input.GetAxis("LeftTrigger");
		float rightTrigger = Input.GetAxis("RightTrigger");
		float leftStick = Input.GetAxis ("LeftStickHoriz");

		leftEngine.AddForce (leftEngine.transform.forward *turningForce* leftTrigger);
		rightEngine.AddForce(rightEngine.transform.forward*turningForce*rightTrigger);
		pod.AddForce (pod.transform.right*-podForce*leftTrigger);
		pod.AddForce (pod.transform.right*podForce*rightTrigger);


		leftEngine.AddRelativeTorque(Input.GetAxis("LeftStickVert")*turningTorque,0,-Input.GetAxis("LeftStickHoriz")*turningTorque);
		rightEngine.AddRelativeTorque(Input.GetAxis("RightStickVert")*turningTorque,0,-Input.GetAxis("RightStickHoriz")*turningTorque);

		//thrust controll
		leftThruster.thrust = leftThruster.DefaultThrust*Input.GetAxis("Throttle");
		rightThruster.thrust = rightThruster.DefaultThrust*Input.GetAxis("Throttle");

		leftThruster.thrust*=(rightTrigger*1/turningThrust+1.0f);//remap from 0-1 to 1-1.1
		rightThruster.thrust*=(leftTrigger*1/turningThrust+1.0f);

	}
	void OnDisable(){
		leftThruster.resetThrust();
		rightThruster.resetThrust();
	}
}
