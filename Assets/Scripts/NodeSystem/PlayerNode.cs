using UnityEngine;
using System.Collections;
public class PlayerNode: MonoBehaviour {
	public Transform currentWayPoint;
	public Transform nextWayPoint;
	public int position;
	public float distanceToNextPoint;

	void Start () {
		//initialize current and next waypoint
	}

	void Update () {
		//print (getDistanceToNextPoint());
		//check distance between way point and player to check for waypoint update
		//(plyaer-currentWayPoint)>(nextWayPoint-currentWayPoint)
		//if (Vector3.Distance(currentWayPoint.position,transform.position)>= Vector3.Distance(currentWayPoint.position,nextWayPoint.position)){
		    //&& Vector3.Distance(nextWayPoint.position,transform.position)<= Vector3.Distance(nextWayPoint.position,currentWayPoint.position))
		
		//	currentWayPoint=nextWayPoint;
		//	nextWayPoint=nextWayPoint.GetComponent<Nodee>().next;
	//}
		// what if plyaer move backwards
		// metheod constantly showing rank
	}

	public float getDistanceToNextPoint(){
		distanceToNextPoint = Vector3.Distance (nextWayPoint.position, transform.position);
		return distanceToNextPoint;
}

}
