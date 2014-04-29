using UnityEngine;
using System.Collections;
public class PlayerNode: MonoBehaviour {
	public Transform currentWayPoint,nextWayPoint;
	public int position,currentLap;
	public float distanceToNextPoint;
	public bool finished;
	public string finishTime;
	Transform wall;
	void Start () {
		wall = GameObject.Find ("Wall").transform;
		currentWayPoint = wall.Find ("35a");
		nextWayPoint = currentWayPoint.GetComponent<NodeA> ().next;
		finishTime="0";

	}

	void Update () {

	}

	public float getDistanceToNextPoint(){
		distanceToNextPoint = Vector3.Distance (nextWayPoint.position, transform.position);
		return distanceToNextPoint;
}
	public void updateWayPointWhenSpawn(Transform wayPoint){
		if (wayPoint.name == "Node1"|| wayPoint.name =="Node55" ||wayPoint.name =="Node56"||wayPoint.name =="Node57")
			changeAsNextWayPoint (wall.Find ("1a"));
		if (wayPoint.name == "Node58"|| wayPoint.name == "Node2" || wayPoint.name == "Node3")
			changeAsNextWayPoint (wall.Find ("3a"));
		if (wayPoint.name == "Node4A" ||wayPoint.name =="Node4B" ||wayPoint.name =="Node7A" ||wayPoint.name =="Node7B"||wayPoint.name =="Node6A"||wayPoint.name =="Node6B"||wayPoint.name =="Node5A"||wayPoint.name =="Node5B")
			changeAsNextWayPoint (wall.Find ("7a"));
		if (wayPoint.name =="Node8A" ||wayPoint.name =="Node8B" ||wayPoint.name =="Node9A" ||wayPoint.name =="Node9B" ||wayPoint.name =="Node10A" ||wayPoint.name =="Node10B" ||wayPoint.name =="Node11A" ||wayPoint.name =="Node11B"||wayPoint.name =="Node12A" ||wayPoint.name =="Node12B")
			changeAsNextWayPoint (wall.Find ("13a"));
		if (wayPoint.name =="Node13" ||wayPoint.name =="Node14" ||wayPoint.name =="Node15"||wayPoint.name =="Node16" ||wayPoint.name =="Node17")
			changeAsNextWayPoint (wall.Find ("18a"));
		if (wayPoint.name =="Node18" ||wayPoint.name =="Node19"||wayPoint.name =="Node20"||wayPoint.name =="Node21")
			changeAsNextWayPoint (wall.Find ("21a"));
		if (wayPoint.name =="Node22" ||wayPoint.name =="Node23"||wayPoint.name =="Node24")
			changeAsNextWayPoint (wall.Find ("25a"  ));
		if (wayPoint.name =="Node25" ||wayPoint.name =="Node25.1"||wayPoint.name =="Node25.2"||wayPoint.name =="Node25.3"||wayPoint.name =="Node25.4")
			changeAsNextWayPoint (wall.Find ("26a"));
		if (wayPoint.name =="Node26" ||wayPoint.name =="Node27"||wayPoint.name =="Node28"||wayPoint.name =="Node29"||wayPoint.name =="Node30")
			changeAsNextWayPoint (wall.Find ("30a"));
		if (wayPoint.name =="Node31" ||wayPoint.name =="Node32"||wayPoint.name =="Node33"||wayPoint.name =="Node34"||wayPoint.name =="Node35"||wayPoint.name =="Node36"||wayPoint.name =="Node37")
			changeAsNextWayPoint (wall.Find ("31a"));
		if (wayPoint.name =="Node38" ||wayPoint.name =="Node39"||wayPoint.name =="Node40"||wayPoint.name =="Node41"||wayPoint.name =="Node42"||wayPoint.name =="Node43")
			changeAsNextWayPoint (wall.Find ("32a"));
		if (wayPoint.name =="Node44" ||wayPoint.name =="Node45"||wayPoint.name =="Node46"||wayPoint.name =="Node47")
			changeAsNextWayPoint (wall.Find ("33a"));
	    if (wayPoint.name =="Node48" ||wayPoint.name =="Node49")
			changeAsNextWayPoint (wall.Find ("34a"));
		if (wayPoint.name =="Node50" ||wayPoint.name =="Node51"||wayPoint.name =="Node52"||wayPoint.name =="Node53"||wayPoint.name =="Node53"||wayPoint.name =="Node54")
			changeAsNextWayPoint (wall.Find ("35a"));
	}

	void changeAsNextWayPoint(Transform wayPoint){
		nextWayPoint = wayPoint;
		currentWayPoint = wayPoint.GetComponent<NodeA> ().previous;
		}

	public void finish(){
		Debug.Log ("finish!");
		finished = true;
		finishTime = GameObject.Find ("Time").GetComponent<TimeHUD> ().guiText.text;
		transform.parent.Find("ShowRank").GetComponent<ShowRank>().guiText.text=transform.parent.Find("ShowRank").GetComponent<ShowRank>().currentPlayer.GetComponent<PlayerNode> ().position.ToString ()+ ",finishTime:" + finishTime;
		GetComponent<InputManager> ().enabled = false;
		GetComponent<PlayerInputManager> ().enabled = false;
		GetComponent<TestEngineController> ().enabled = false;
		GameObject.Find ("Rank").GetComponent<Rank> ().notFinishedPod--;
		GameObject.Find ("Rank").GetComponent<Rank> ().checkFinsh();

	}

}
