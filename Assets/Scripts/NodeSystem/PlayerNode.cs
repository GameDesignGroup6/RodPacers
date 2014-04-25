using UnityEngine;
using System.Collections;
public class PlayerNode: MonoBehaviour {
	public Transform currentWayPoint;
	public Transform nextWayPoint;
	public int position;
	public float distanceToNextPoint;
	public int currentLap;
	void Start () {

		nextWayPoint = currentWayPoint.GetComponent<NodeA> ().next;
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
	public void finish(){
		Debug.Log ("finish!");
		GameObject.Find ("rank").GetComponent<Rank> ().guiText.text = GameObject.Find ("rank").GetComponent<Rank> ().currentPlayer.GetComponent<PlayerNode> ().position.ToString () + ",finishTime:" + GameObject.Find ("Time").GetComponent<TimeHUD> ().guiText.text;
		GetComponent<InputManager> ().enabled = false;
		GetComponent<PlayerInputManager> ().enabled = false;
		GetComponent<TestEngineController> ().enabled = false;
		GameObject.Find ("rank").GetComponent<Rank> ().notFinishedPod--;
		GameObject.Find ("rank").GetComponent<Rank> ().finish=true;

	}

}
