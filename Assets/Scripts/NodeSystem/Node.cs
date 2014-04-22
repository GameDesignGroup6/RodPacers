using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {
	public Node next,previous;
	private float distance;
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
	private Vector3 pos;
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
	}

	void Awake(){
		pos = transform.position;
	}

	public void updateTotalLength(bool propigate){
		if(start){
			distance = 0f;
		}else distance = previous.DistanceFromStart+Vector3.Distance(Position,previous.Position);

		if(propigate&&!next.start)next.updateTotalLength(true); //do not continue to the start line again, else this is infinite!
	}
}
