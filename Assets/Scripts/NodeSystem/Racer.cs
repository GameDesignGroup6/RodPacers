using UnityEngine;
using System.Collections;

public class Racer : MonoBehaviour {
	public Node nearestNode;
	private float distanceFromNode;
	private bool evenTick = true;//to prevent lag, we do different actions every other FixedUpdate
	public float DistanceFromStart{
		get{
			return distanceFromNode+nearestNode.DistanceFromStart;
		}
	}
	private bool backwards;
	public bool FacingBackwards{
		get{return backwards;}
	}
	private Vector3 avgVeloc;
	public Vector3 AverageVelocity{
		get{return avgVeloc;}
	}
	public float DistanceFromClosestNode{
		get{
			return distanceFromNode;
		}
	}
	private Vector3 avgPos;
	public Vector3 AveragePosition{
		get{return avgPos;}
	}

	void FixedUpdate () {
		evenTick = !evenTick;
		if(evenTick){//recalculate the nearestNode
			CalculateNearestNode();
		}else{//recalculate if the player is going forward using Vector3.Angle()
			//the way this part should work is that if the angle between the
			//player's velocity vector and the vector from the current Node to the next Node is less than 90 degrees,
			//then the player is facing forward.
			//PROBLEM:
			//the racers have three rigidBodies that all move semi-independently
			//I need to calculate the average Velocity which may be expensive
			//It should only be done at most once per FixedUpdate 
			//I guess this class is as good as any to do it...
			Vector3 nodeVector = nearestNode.VectorToNextNode;
			CalculateAverageVelocityAndPosition();
			backwards = Vector3.Angle(AverageVelocity,nodeVector)>90f;
		}
	}
	private void CalculateNearestNode(){
		//compute three distances for comparison
		//1. distance from current Node
		//2. distance from previous Node
		//3. distance from next Node
		//
		//set the nearestNode to whichever is smallest
		//update distanceFromNode accordingly
		
		Vector3 curPos = avgPos;
		if(curPos.Equals(Vector3.zero))return;//the other code hasn't run yet
		//sqrMagnitude is much faster than regular magnitude because it doesn't take the square root
		float sqDistanceFromCur = (nearestNode.Position-curPos).sqrMagnitude;
		float sqDistanceFromPrev = (nearestNode.next.Position-curPos).sqrMagnitude;
		float sqDistanceFromNext = (nearestNode.previous.Position-curPos).sqrMagnitude;
		
		if(sqDistanceFromCur<sqDistanceFromPrev && sqDistanceFromCur<sqDistanceFromNext){//the current distance is least!
			//no change...
			distanceFromNode = Mathf.Sqrt(sqDistanceFromCur);
		}else if(sqDistanceFromPrev<sqDistanceFromCur && sqDistanceFromPrev<sqDistanceFromNext){//previous is least (going backwards!)
			nearestNode = nearestNode.previous;
			distanceFromNode = Mathf.Sqrt(sqDistanceFromPrev);
		}else if(sqDistanceFromNext<sqDistanceFromPrev && sqDistanceFromNext<sqDistanceFromCur){//next is the least!
			nearestNode = nearestNode.next;
			distanceFromNode = Mathf.Sqrt(sqDistanceFromNext);
		}else{
			//in the last case (two of the values are equal) we will just maintain the current Node, but still update the distance
			distanceFromNode = Mathf.Sqrt(sqDistanceFromCur);
		}
		//a quick note for the curious:
		//this code only looks at the Nodes directly before and after the current one,
		//but you may be asking, what if the player skips a node?
		//the answer is quite simple:
		//The next time the nearest Node is calculated, the player should be closest to the next Node (the one they skipped)
		//compared to the current one.  The next Node now becomes the current one.  Then, the next time the current Node is calculated,
		//the CurrentNode will actually be the correct one.
		//tl;dr: the currentNode may take longer to change then the player took to get to it, if they skipped a node
	}
	private void CalculateAverageVelocityAndPosition(){
		Vector3 sum = Vector3.zero;
		Vector3 posSum = Vector3.zero;
		int count = 0;
		foreach(Rigidbody r in GetComponentsInChildren<Rigidbody>()){
			count++;
			sum+=r.velocity;
			posSum+=r.position;
		}
		if(count<=0){
			avgVeloc = Vector3.zero;
			avgPos = Vector3.zero;
		}else{
			avgVeloc = sum/count;
			avgPos = posSum/count;
		}
	}
}
