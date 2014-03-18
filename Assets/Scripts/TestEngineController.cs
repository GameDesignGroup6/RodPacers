using UnityEngine;
using System.Collections;

public class TestEngineController : MonoBehaviour {
	public Rigidbody leftEngine,rightEngine;
	public bool go = true;
	public bool acceptUserInput = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(go){
			Vector3 leftForce = leftEngine.transform.up*50;
			Vector3 rightForce=rightEngine.transform.up*50;
			leftEngine.AddForce(leftForce);
			rightEngine.AddForce(rightForce);
		}
		if(!acceptUserInput)return;
		float leftTrigger = Input.GetAxis("LeftTrigger");
		float rightTrigger = Input.GetAxis("RightTrigger");

		leftEngine.AddForce (leftEngine.transform.forward *20* leftTrigger);
		rightEngine.AddForce(rightEngine.transform.forward*20*rightTrigger);


//		float leftAdjust = (Input.GetAxis("LeftTrigger")-0.5f)*2;
//		float rightAdjust = (Input.GetAxis("RightTrigger")-0.5f)*2;
		//values are now mapped between -1.0 and 1.0
//		float combined = Input.GetAxis("LeftTrigger")-Input.GetAxis("RightTrigger");

//		leftEngine.AddRelativeTorque(new Vector3(0f,Input.GetAxis("LeftTrigger"),0f));
//		rightEngine.AddRelativeTorque(new Vector3(0f,-Input.GetAxis("RightTrigger"),0f));

		leftEngine.AddRelativeTorque(Input.GetAxis("LeftStickVert")*50,0,-Input.GetAxis("LeftStickHoriz")*50);
		rightEngine.AddRelativeTorque(Input.GetAxis("RightStickVert")*50,0,-Input.GetAxis("RightStickHoriz")*50);
	}
}
