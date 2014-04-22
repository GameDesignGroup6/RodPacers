using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {
	public Node next,previous;
	private float distance;
	public bool checkpoint;
	public bool start;
	private Vector3 pos;
	
	public int numNodes;

	public Node getNext(){
		get{return next;}
	}

	public Node getPrev(){
		getNext{return previous;}
	}

	void OnTriggerEnter(Collider racer){
		var pod = racer.GetComponent<PodScript>();
		if (this == pod.goalNode){ //this condition makes it so that the player cannot go backwards to win.
			pod.currentNode=pod.goalNode;
			if (this.getNext()==null){
				Debug.Log(pod.name " won the game");
				//do victory stuff
				return;
			}
			pod.goalNode=this.getNext();
			pod.passedANode();
		}
	}

	public Vector3 Position{
		get{return pos;}
	}
	public float DistanceFromStart{
		get{return distance;}
	}
	public Vector3 VectorToNextNode{
		get{
			return next.pos-pos;
		}
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
