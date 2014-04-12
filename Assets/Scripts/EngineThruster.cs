using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class EngineThruster : MonoBehaviour {
	public DirectionOptions ThrustDirection = DirectionOptions.up;
	
	public enum DirectionOptions{up,down,left,right,forward,backward}

	public float thrust;

	private float startThrust;
	public float DefaultThrust{
		get{return startThrust;}
	}

	private Rigidbody rgb;

	[System.NonSerialized]
	public Vector3 thrustDirection;

	public void resetThrustDirection(){
		switch(ThrustDirection){
		case DirectionOptions.forward:thrustDirection = Vector3.forward;break;
		case DirectionOptions.backward:thrustDirection = -Vector3.forward;break;
		case DirectionOptions.up:thrustDirection = Vector3.up;break;
		case DirectionOptions.down:thrustDirection = -Vector3.up;break;
		case DirectionOptions.right:thrustDirection = Vector3.right;break;
		case DirectionOptions.left:thrustDirection = -Vector3.right;break;
		}
	}
//	void OnDrawGizmosSelected(){
//		Gizmos.DrawRay(transform.position,thrustDirection);
//	}

	public void resetThrust(){
		thrust = startThrust;
	}
	
	void Start () {
		startThrust = thrust;
		rgb = rigidbody;
		resetThrustDirection();
		thrust = 0f;
	}

	void FixedUpdate () {
		rgb.AddRelativeForce(thrustDirection*thrust);
	}
}
