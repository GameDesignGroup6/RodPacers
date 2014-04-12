using UnityEngine;
using System.Collections;

public class ForwardStabilizer : MonoBehaviour {
	private Rigidbody rgb;
	private Transform trans;
	private Vector3 relativePoint;//yea... this point is actually in world coords...
	private Vector3 normalVelocity;


	// Use this for initialization
	void Start () {
		rgb = rigidbody;
		trans= transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		UpdateRelativePoint();
		UpdateNormalVelocity();
		rgb.AddForceAtPosition(normalVelocity,relativePoint);

	}
	private void UpdateNormalVelocity(){
		normalVelocity = Vector3.Normalize(rgb.velocity);
		normalVelocity.x*=normalVelocity.x;
		normalVelocity.y=0f;
		normalVelocity.z*=normalVelocity.z;
	}

	private void UpdateRelativePoint(){
		relativePoint = trans.TransformPoint(trans.up*5);
	}
	void OnDrawGizmosSelected(){
		Start();
		UpdateRelativePoint();
		UpdateNormalVelocity();
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(relativePoint,0.1f);
		Gizmos.color = Color.green;
		Gizmos.DrawRay(relativePoint,normalVelocity);
	}
}
