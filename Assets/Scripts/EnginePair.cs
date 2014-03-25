using UnityEngine;
using System.Collections;

public class EnginePair : MonoBehaviour {
	public Engine left;
	public Engine right;
	public float k = 1.0f;

	private float targetLeftRight,targetRightLeft;//distance at start
	private float targetFront,targetRear;//distance at start
	private float targetMain;//distance at start of the actual transforms;

	[System.Serializable]
	public class Engine{
		public Rigidbody body;
		public Transform frontAnchor;
		public Transform rearAnchor;
		[System.NonSerialized]
		public Transform main;
	}

	// Use this for initialization
	void Start () {
		targetLeftRight = Vector3.Distance (left.frontAnchor.position,right.rearAnchor.position);//LR
		targetRightLeft = Vector3.Distance (left.rearAnchor.position,right.frontAnchor.position);// RL
		targetFront = Vector3.Distance (left.frontAnchor.position,right.frontAnchor.position);
		targetRear = Vector3.Distance (left.rearAnchor.position,right.rearAnchor.position);
		left.main = left.body.transform;
		right.main = right.body.transform;
		targetMain = Vector3.Distance(left.main.position,right.main.position);
	}

	void FixedUpdate(){
		DoCross ();
		DoParallel();
//		DoParallelFlat();
		DoSeperate();
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
		float frontDelta = Vector3.Distance(left.frontAnchor.position,right.frontAnchor.position)-targetFront;
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
	private void DoParallelFlat () {
		//let's start with the front anchors
		Vector3 leftFrontPos = left.frontAnchor.position;
		Vector3 rightFrontPos = right.frontAnchor.position;
		leftFrontPos.y = 0.0f;
		rightFrontPos.y = 0.0f;


		float frontDelta = Vector3.Distance(leftFrontPos,rightFrontPos)-targetFront;
		Vector3 frontForce = (rightFrontPos-leftFrontPos)*frontDelta*k;//leftFrontForce
		left.body.AddForceAtPosition(frontForce,left.frontAnchor.position);
		right.body.AddForceAtPosition(-frontForce,right.frontAnchor.position);
		Debug.DrawRay(left.frontAnchor.position,frontForce,Color.white);
		Debug.DrawRay(right.frontAnchor.position, -frontForce,Color.white);
		
		//now the rear!
		Vector3 leftRearPos = left.rearAnchor.position;
		Vector3 rightRearPos = right.rearAnchor.position;
		leftRearPos.y = 0.0f;
		rightRearPos.y = 0.0f;
		float rearDist = Vector3.Distance(leftRearPos,rightRearPos);
		float rearDelta = rearDist-targetRear;
		Vector3 rearForce = ((rightRearPos-leftRearPos)/rearDist)*k*rearDelta;//leftRearForce
		left.body.AddForceAtPosition(rearForce,left.rearAnchor.position);
		right.body.AddForceAtPosition(-rearForce,right.rearAnchor.position);
		Debug.DrawRay(left.rearAnchor.position,rearForce,Color.white);
		Debug.DrawRay(right.rearAnchor.position, -rearForce,Color.white);
	}
	private void DoSeperate () {
		Vector3 leftPos = left.main.position;
		Vector3 rightPos = right.main.position;
		leftPos.y = 0.0f;
		rightPos.y = 0.0f;

		float dist = Vector3.Distance(leftPos,rightPos);
		float delta = dist-targetMain;
		Vector3 force = ((rightPos-leftPos)/dist)*delta*k;


		//I need to detect if the engines have switched places...
		//how do I do that...?
		//NOTE: the right engine should always be (realitive to the left engine) in the positive x direction
		//therefore, if I transform the right engine's world position using the left engine's transform, and the x cord is negative, they've switched places! yes! thinking!
		if(left.main.InverseTransformPoint(right.main.position).x<0){
			//we're backwards!
			force = ((rightPos-leftPos)/dist)*k*k*k;
			Debug.Log ("Engines are switched!");
			DebugHUD.setValue("Engines Switched","<color=red>TRUE</color>" as System.Object);
		}else{
			DebugHUD.setValue("Engines Switched","<color=green>FALSE</color>" as System.Object);
		}


		left.body.AddForce(force);
		right.body.AddForce(-force);
		Debug.DrawRay(left.main.position,force,Color.white);
		Debug.DrawRay(right.main.position,-force,Color.white);
		

	}
}
