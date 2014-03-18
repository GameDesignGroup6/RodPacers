﻿using UnityEngine;
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

		leftEngine.AddRelativeTorque(Input.GetAxis("LeftStickVert")*50,0,-Input.GetAxis("LeftStickHoriz")*50);
		rightEngine.AddRelativeTorque(Input.GetAxis("RightStickVert")*50,0,-Input.GetAxis("RightStickHoriz")*50);
	}
}
