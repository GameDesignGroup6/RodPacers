using UnityEngine;
using System.Collections;

public class TestEngineController : MonoBehaviour {
	public Rigidbody leftEngine,rightEngine;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float leftTrigger = Input.GetAxis("LeftTrigger");
		float rightTrigger = Input.GetAxis("RightTrigger");

		Vector3 leftForce = leftEngine.transform.up*200*leftTrigger;
		Vector3 rightForce=rightEngine.transform.up*200*rightTrigger;
		leftEngine.AddForce(leftForce);
		rightEngine.AddForce(rightForce);

//		float leftAdjust = (Input.GetAxis("LeftTrigger")-0.5f)*2;
//		float rightAdjust = (Input.GetAxis("RightTrigger")-0.5f)*2;
		//values are now mapped between -1.0 and 1.0
//		float combined = Input.GetAxis("LeftTrigger")-Input.GetAxis("RightTrigger");

//		leftEngine.AddRelativeTorque(new Vector3(0f,Input.GetAxis("LeftTrigger"),0f));
//		rightEngine.AddRelativeTorque(new Vector3(0f,-Input.GetAxis("RightTrigger"),0f));

		leftEngine.AddRelativeTorque(Input.GetAxis("LeftStickVert")*100,0,-Input.GetAxis("LeftStickHoriz")*100);
		rightEngine.AddRelativeTorque(Input.GetAxis("RightStickVert")*100,0,-Input.GetAxis("RightStickHoriz")*100);
	}
}
