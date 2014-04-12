using UnityEngine;
using System.Collections;

public class SecondTestEngineController : MonoBehaviour {

	public int playerNumber;
	public EngineThruster podThruster;
	public float turningForce;
	public float angleForce;
	public Rigidbody podRacer;
	public bool acceptUserInput = true;
	public static bool acceptUserInputOn;

	// Update is called once per frame
	void Update () {
		
		if(!acceptUserInput){Input.ResetInputAxes();}
		float leftTrigger = Input.GetAxis("LeftTrigger" + playerNumber);
		float rightTrigger = Input.GetAxis("RightTrigger" + playerNumber);
		
		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer) {
			leftTrigger = (leftTrigger +1)/2;
			rightTrigger = (rightTrigger +1)/2;
		}


		rigidbody.AddForce (transform.forward );
		rigidbody.AddRelativeForce (new Vector3(0, turningForce*rightTrigger, 0));

		rigidbody.AddRelativeTorque (new Vector3(0, 0, turningForce*leftTrigger));
		rigidbody.AddRelativeTorque (new Vector3(0, 0, turningForce*-rightTrigger));
		
		podThruster.thrust = podThruster.DefaultThrust*Input.GetAxis("Throttle"+playerNumber);
	}

	void OnDisable () {
		podThruster.resetThrust();
	}
}
