using UnityEngine;
using System.Collections;

public class EnginePair : MonoBehaviour {
	public Engine left;
	public Engine right;
	public float k = 1.0f;

	private float targetLeftRight,targetRightLeft;//distance at start
	private float targetFront,targetRear;//distance at start
	private float targetMain;//distance at start of the actual transforms;
	private bool priSwitch;

	public float TargetDistance{
		get{return targetMain;}
	}
	public bool EnginesSwitched{
		get{return priSwitch;}
	}

//	[System.Serializable]
//	public class Engine{
//		public Rigidbody body;
//		public Transform frontAnchor;
//		public Transform rearAnchor;
//		[System.NonSerialized]
//		public Transform main;
//	}

	// Use this for initialization
	void Start () {
		targetLeftRight = Vector3.Distance (left.FrontLink.position,right.RearLink.position);//LR
		targetRightLeft = Vector3.Distance (left.RearLink.position,right.FrontLink.position);// RL
		targetFront = Vector3.Distance (left.FrontLink.position,right.FrontLink.position);
		targetRear = Vector3.Distance (left.RearLink.position,right.RearLink.position);
		targetMain = Vector3.Distance(left.EngineTransform.position,right.EngineTransform.position);
	}

	void FixedUpdate(){
		DoCross ();
		DoParallel();
//		DoParallelFlat();
		DoSeperate();
	}

	private void DoCross () {
		//let's start with frontLeft-rearRight
		float frontDelta = Vector3.Distance (left.FrontLink.position,right.RearLink.position)-targetLeftRight;
		Vector3 frontForce = (right.RearLink.position-left.FrontLink.position)*frontDelta*k;//leftFrontForce
		left.EngineRigidbody.AddForceAtPosition(frontForce,left.FrontLink.position);
		right.EngineRigidbody.AddForceAtPosition(-frontForce,right.RearLink.position);
		Debug.DrawRay(left.FrontLink.position,frontForce,Color.red);
		Debug.DrawRay(right.RearLink.position, -frontForce,Color.red);

		//now RL
		float rearDelta = Vector3.Distance (left.RearLink.position,right.FrontLink.position)-targetRightLeft;
		Vector3 rearForce = (right.FrontLink.position-left.RearLink.position)*k*rearDelta;//leftRearForce
		left.EngineRigidbody.AddForceAtPosition(rearForce,left.RearLink.position);
		right.EngineRigidbody.AddForceAtPosition(-rearForce,right.FrontLink.position);
		Debug.DrawRay(left.RearLink.position,rearForce,Color.red);
		Debug.DrawRay(right.FrontLink.position, -rearForce,Color.red);
	}
	//old code
	private void DoParallel () {
		//let's start with the front anchors
		float frontDelta = Vector3.Distance(left.FrontLink.position,right.FrontLink.position)-targetFront;
		Vector3 frontForce = (right.FrontLink.position-left.FrontLink.position)*frontDelta*k;//leftFrontForce
		left.EngineRigidbody.AddForceAtPosition(frontForce,left.FrontLink.position);
		right.EngineRigidbody.AddForceAtPosition(-frontForce,right.FrontLink.position);
		Debug.DrawRay(left.FrontLink.position,frontForce,Color.blue);
		Debug.DrawRay(right.FrontLink.position, -frontForce,Color.blue);
		
		//now the rear!
		float rearDelta = Vector3.Distance (left.RearLink.position,right.RearLink.position)-targetRear;
		Vector3 rearForce = (right.RearLink.position-left.RearLink.position)*k*rearDelta;//leftRearForce
		left.EngineRigidbody.AddForceAtPosition(rearForce,left.RearLink.position);
		right.EngineRigidbody.AddForceAtPosition(-rearForce,right.RearLink.position);
		Debug.DrawRay(left.RearLink.position,rearForce,Color.blue);
		Debug.DrawRay(right.RearLink.position, -rearForce,Color.blue);
	}
	private void DoParallelFlat () {
		//let's start with the front anchors
		Vector3 leftFrontPos = left.FrontLink.position;
		Vector3 rightFrontPos = right.FrontLink.position;
		leftFrontPos.y = 0.0f;
		rightFrontPos.y = 0.0f;


		float frontDelta = Vector3.Distance(leftFrontPos,rightFrontPos)-targetFront;
		Vector3 frontForce = (rightFrontPos-leftFrontPos)*frontDelta*k;//leftFrontForce
		left.EngineRigidbody.AddForceAtPosition(frontForce,left.FrontLink.position);
		right.EngineRigidbody.AddForceAtPosition(-frontForce,right.FrontLink.position);
		Debug.DrawRay(left.FrontLink.position,frontForce,Color.white);
		Debug.DrawRay(right.FrontLink.position, -frontForce,Color.white);
		
		//now the rear!
		Vector3 leftRearPos = left.RearLink.position;
		Vector3 rightRearPos = right.RearLink.position;
		leftRearPos.y = 0.0f;
		rightRearPos.y = 0.0f;
		float rearDist = Vector3.Distance(leftRearPos,rightRearPos);
		float rearDelta = rearDist-targetRear;
		Vector3 rearForce = ((rightRearPos-leftRearPos)/rearDist)*k*rearDelta;//leftRearForce
		left.EngineRigidbody.AddForceAtPosition(rearForce,left.RearLink.position);
		right.EngineRigidbody.AddForceAtPosition(-rearForce,right.RearLink.position);
		Debug.DrawRay(left.RearLink.position,rearForce,Color.white);
		Debug.DrawRay(right.RearLink.position, -rearForce,Color.white);
	}
	private void DoSeperate () {
		Vector3 leftPos = left.EngineTransform.position;
		Vector3 rightPos = right.EngineTransform.position;
		leftPos.y = 0.0f;
		rightPos.y = 0.0f;

		float dist = Vector3.Distance(leftPos,rightPos);
		float delta = dist-targetMain;
		Vector3 force = ((rightPos-leftPos)/dist)*delta*k;


		//I need to detect if the engines have switched places...
		//how do I do that...?
		//NOTE: the right engine should always be (realitive to the left engine) in the positive x direction
		//therefore, if I transform the right engine's world position using the left engine's transform, and the x cord is negative, they've switched places! yes! thinking!
		if(left.EngineTransform.InverseTransformPoint(right.EngineTransform.position).x<0){
			//we're backwards!
			priSwitch = true;
			force = ((rightPos-leftPos)/dist)*k*k*k;
		}else{
			priSwitch = false;
		}


		left.EngineRigidbody.AddForce(force);
		right.EngineRigidbody.AddForce(-force);
		Debug.DrawRay(left.EngineTransform.position,force,Color.white);
		Debug.DrawRay(right.EngineTransform.position,-force,Color.white);
		

	}
}
