using UnityEngine;
using System.Collections;

public class TestEngineController : MonoBehaviour {
	public Rigidbody leftEngine,rightEngine;
	public EngineThruster leftThruster,rightThruster;
	public bool acceptUserInput = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyDown(KeyCode.G)){
			acceptUserInput = true;
			foreach(HoverChock h in FindObjectsOfType<HoverChock>()){
				h.isActive = false;
				h.enabled = false;
			}
		}


		if(!acceptUserInput){Input.ResetInputAxes();}
		float leftTrigger = Input.GetAxis("LeftTrigger");
		float rightTrigger = Input.GetAxis("RightTrigger");

		leftEngine.AddForce (leftEngine.transform.forward *20* leftTrigger);
		rightEngine.AddForce(rightEngine.transform.forward*20*rightTrigger);

		leftEngine.AddRelativeTorque(Input.GetAxis("LeftStickVert")*50,0,-Input.GetAxis("LeftStickHoriz")*50);
		rightEngine.AddRelativeTorque(Input.GetAxis("RightStickVert")*50,0,-Input.GetAxis("RightStickHoriz")*50);

		//thrust controll
		leftThruster.thrust = leftThruster.DefaultThrust*Input.GetAxis("Throttle");
		rightThruster.thrust = rightThruster.DefaultThrust*Input.GetAxis("Throttle");

		leftThruster.thrust*=(rightTrigger/10f+1.0f);//remap from 0-1 to 1-1.1
		rightThruster.thrust*=(leftTrigger/10f+1.0f);

	}
	void OnDisable(){
		leftThruster.resetThrust();
		rightThruster.resetThrust();
	}
}
