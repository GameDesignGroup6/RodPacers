using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {
	public Node next, previous;
	public Node branch = null;
	private float distance;
	public float xMin = -100f,xMax = 100f,zMin = -100f,zMax = 100f;
	public float DistanceFromStart{
		get{return distance;}
	}
	public Vector3 VectorToNextNode{
		get{
			return next.pos-pos;
		}
	}
	public bool checkpoint;
	public bool start;
    public Vector3 pos;
	public Vector3 Position{
		get{return pos;}
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.yellow;
		if(checkpoint)Gizmos.color = Color.blue;
		if(start)Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position,10f);
		if(next){
			Gizmos.color = Color.green;
			if(next.previous!=this)Gizmos.color = Color.red;
			Gizmos.DrawLine(transform.position,next.transform.position);
		}
		Gizmos.color = Color.cyan;
		float x = (transform.position.x*2f+xMin+xMax)/2f;
		float z = (transform.position.z*2f+zMin+zMax)/2f;
		Vector3 boxPos = new Vector3(x,transform.position.y,z);
		Vector3 bounds = new Vector3(xMax-xMin,20f,zMax-zMin);
		Gizmos.DrawWireCube(boxPos,bounds);
	}

	void Awake(){
		pos = transform.position;
	}
	void Start(){
		if(start){
			updateTotalLength(true);
		}
	}

	public void updateTotalLength(bool propigate){
		if(start){
			distance = 0f;
			next.updateTotalLength(true);
			return;
		}else distance = previous.DistanceFromStart+Vector3.Distance(Position,previous.Position);
		Debug.Log ("Setup "+name);
		if(propigate&&!next.start&&next.name!="Node2")next.updateTotalLength(true); //do not continue to the start line again, else this is infinite!
		if(branch)branch.distance = distance;
	}
}
