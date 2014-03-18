using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class HoverScript : MonoBehaviour {
	public Transform[] points;
	public float targetHeight;
	public float k;
	public DirectionOptions upwardsDirection = DirectionOptions.up;

	public enum DirectionOptions{up,down,left,right,forward,backward}

	private Rigidbody rgb;
	private Transform trans;
	private Collider col;
	private Vector3 up;


	// Use this for initialization
	void Start () {
		OnValidate();
	}
	void OnValidate(){
		rgb = rigidbody;
		trans = this.transform;
		col = collider;
		switch(upwardsDirection){
		case DirectionOptions.forward:up = Vector3.forward;break;
		case DirectionOptions.backward:up = -Vector3.forward;break;
		case DirectionOptions.up:up = Vector3.up;break;
		case DirectionOptions.down:up = -Vector3.up;break;
		case DirectionOptions.right:up = Vector3.right;break;
		case DirectionOptions.left:up = -Vector3.right;break;
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.yellow;
		foreach(Transform t in points)
			Gizmos.DrawSphere(t.position,0.1f);
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.TransformPoint(5*up),0.1f);
	}

	void FixedUpdate () {
		if(rgb==null)rgb = rigidbody;
//		trans.rotation = Quaternion.RotateTowards(trans.rotation,Quaternion.LookRotation(Vector3.forward),1f);
		rgb.AddForceAtPosition(2*Vector3.up,trans.TransformPoint(5*up));

		foreach(Transform t in points){
			RaycastHit hit;
			//Hooke's law: F=kx
			if(Physics.Raycast(t.position,Vector3.down,out hit)){
				if(hit.collider != col && !hit.collider.CompareTag("Engine")){//don't hover on other engines!
					Debug.DrawRay(t.position,Vector3.down,Color.red);
					Debug.DrawRay(hit.point,hit.normal,Color.green);
					float delta = hit.distance-targetHeight;
					float force = k*delta;
					Vector3 forceVector = hit.normal*force;
					rgb.AddForceAtPosition(forceVector,t.position,ForceMode.Force);
					Debug.DrawRay(t.position,forceVector,Color.blue);
				}
			}
		}
//		foreach(Vector3 t in raycastPoints){
//			RaycastHit hit = null;
//			//Hooke's law: F=kx
//			Vector3 pos = trans.position+t;
//			if(Physics.Raycast(pos,Vector3.down,out hit)){
//				Debug.DrawRay(pos,Vector3.down,Color.green);
//				float force = k*(hit.distance-targetHeight);
//				Debug.Log("Applying force of "+force+" at coords "+t);
//				rgb.AddForceAtPosition(Vector3.down*force,pos,ForceMode.Force);
//			}
//		}
	}
}
