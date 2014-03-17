using UnityEngine;
using System.Collections;

public class EnginePair : MonoBehaviour {
	public Engine left;
	public Engine right;
	public float k = 1.0f;

	private float targetLeftRight,targetRightLeft;//distance at start
	private float targetFront,targetRear;//distance at start

	[System.Serializable]
	public class Engine{
		public Rigidbody body;
		public Transform frontAnchor;
		public Transform rearAnchor;
	}

	// Use this for initialization
	void Start () {
		targetLeftRight = Vector3.Distance (left.frontAnchor.position,right.rearAnchor.position);//LR
		targetRightLeft = Vector3.Distance (left.rearAnchor.position,right.frontAnchor.position);// RL
		//old code for safekeeping
		targetFront = Vector3.Distance (left.frontAnchor.position,right.frontAnchor.position);
		targetRear = Vector3.Distance (left.rearAnchor.position,right.rearAnchor.position);
	}

	void FixedUpdate(){
		DoCross ();
		DoParallel();
	}

	private void DoCross () {
		//let's start with frontLeft-rearRight
		float frontDelta = Vector3.Distance (left.frontAnchor.position,right.rearAnchor.position)-targetLeftRight;
		Vector3 frontForce = (right.rearAnchor.position-left.frontAnchor.position)*frontDelta*k;//leftFrontForce
		left.body.AddForceAtPosition(frontForce,left.frontAnchor.position);
		right.body.AddForceAtPosition(-frontForce,right.rearAnchor.position);
		Debug.DrawRay(left.frontAnchor.position,frontForce,Color.red);
		Debug.DrawRay(right.rearAnchor.position, -frontForce,Color.red);

		//now RL
		float rearDelta = Vector3.Distance (left.rearAnchor.position,right.frontAnchor.position)-targetRightLeft;
		Vector3 rearForce = (right.frontAnchor.position-left.rearAnchor.position)*k*rearDelta;//leftRearForce
		left.body.AddForceAtPosition(rearForce,left.rearAnchor.position);
		right.body.AddForceAtPosition(-rearForce,right.frontAnchor.position);
		Debug.DrawRay(left.rearAnchor.position,rearForce,Color.red);
		Debug.DrawRay(right.frontAnchor.position, -rearForce,Color.red);
	}
	//old code
	private void DoParallel () {
		//let's start with the front anchors
		float frontDelta = Vector3.Distance (left.frontAnchor.position,right.frontAnchor.position)-targetFront;
		Vector3 frontForce = (right.frontAnchor.position-left.frontAnchor.position)*frontDelta*k;//leftFrontForce
		left.body.AddForceAtPosition(frontForce,left.frontAnchor.position);
		right.body.AddForceAtPosition(-frontForce,right.frontAnchor.position);
		Debug.DrawRay(left.frontAnchor.position,frontForce,Color.blue);
		Debug.DrawRay(right.frontAnchor.position, -frontForce,Color.blue);
		
		//now the rear!
		float rearDelta = Vector3.Distance (left.rearAnchor.position,right.rearAnchor.position)-targetRear;
		Vector3 rearForce = (right.rearAnchor.position-left.rearAnchor.position)*k*rearDelta;//leftRearForce
		left.body.AddForceAtPosition(rearForce,left.rearAnchor.position);
		right.body.AddForceAtPosition(-rearForce,right.rearAnchor.position);
		Debug.DrawRay(left.rearAnchor.position,rearForce,Color.blue);
		Debug.DrawRay(right.rearAnchor.position, -rearForce,Color.blue);
	}
}
