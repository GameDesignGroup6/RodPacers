using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class HoverScript : MonoBehaviour {
	public Transform[] points;
	public float targetHeight;
	public float k;
	public DirectionOptions upwardsDirection = DirectionOptions.up;
	public EngineThruster leftThruster,rightThruster;
	public int stallHeight;
	public float gravity;
	public float stabHeight = 5;

	public float AverageHoverHeight{
		get{return average;}
	}
	private float average;
	private float sum;
	private int hitsThisFrame;

	public enum DirectionOptions{up,down,left,right,forward,backward}

	private Rigidbody rgb;
	private Transform trans;
	private Collider col;
	private Vector3 up;


	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
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
		Gizmos.DrawSphere(transform.TransformPoint(stabHeight*up),0.1f);
	}

	void FixedUpdate () {
		if(rgb==null)rgb = rigidbody;
		rgb.AddForceAtPosition(2*Vector3.up,trans.TransformPoint(stabHeight*up));

		sum = 0;
		hitsThisFrame = 0;
		foreach(Transform t in points){
			RaycastHit hit;
			//Hooke's law: F=kx
			if(Physics.Raycast(t.position,t.forward,out hit)){
				if(hit.collider != col && hit.distance < stallHeight){//don't hover on other engines!
					Debug.DrawRay(t.position,t.forward,Color.red);
					Debug.DrawRay(hit.point,hit.normal,Color.green);
					float delta = hit.distance-targetHeight;
					sum += hit.distance;
					hitsThisFrame++;
					float force = k*delta;
					if(delta<0f){
						force*=(targetHeight/hit.distance);
					}
					Vector3 forceVector = hit.normal*force;
					rgb.AddForceAtPosition(forceVector,t.position,ForceMode.Force);
					Debug.DrawRay(t.position,forceVector,Color.blue);
				}
				else if (hit.distance > stallHeight) {
					rgb.AddForce(0, -gravity, 0);
				}
			}
		}
		if(hitsThisFrame!=0){
			average = sum/hitsThisFrame;
		}else{
			average = -1;
		}
	}
}
