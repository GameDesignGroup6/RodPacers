using UnityEngine;
using System.Collections;

[RequireComponent(typeof(InputManager))]
public class TestEngineController : MonoBehaviour {
	private InputManager manager;
	public Rigidbody leftEngine,rightEngine, bothEngines;
	public EngineThruster leftThruster,rightThruster;
	public bool acceptUserInput = true;
	public static bool acceptUserInputOn;
	public float turningForce = 20f;
	public float turningTorque = 20f;
	public float turningThrust = 5f;

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		acceptUserInputOn = acceptUserInput;
		manager = GetComponent<InputManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!acceptUserInputOn)
			acceptUserInput = false;
		if(Input.GetKeyDown(KeyCode.G)){
			acceptUserInput = true;
		}



		float leftTrigger = manager.getLeftTrigger();
		float rightTrigger = manager.getRightTrigger();

		float throttle = manager.getThrottle();

		if(!acceptUserInput){
			leftTrigger = 0;
			rightTrigger = 0;
			throttle = 0;
		}

		leftEngine.AddForce (leftEngine.transform.forward *turningForce* leftTrigger);
		rightEngine.AddForce(rightEngine.transform.forward*turningForce*rightTrigger);

		//thrust control
		leftThruster.thrust = leftThruster.DefaultThrust*throttle;
		rightThruster.thrust = rightThruster.DefaultThrust*throttle;

		leftThruster.thrust*=(rightTrigger*1/turningThrust+1.0f);
		rightThruster.thrust*=(leftTrigger*1/turningThrust+1.0f);

	}
	void OnDisable(){
		leftThruster.resetThrust();
		rightThruster.resetThrust();
	}
}
