using UnityEngine;
using System.Collections;
public class PlayerNode: MonoBehaviour {
	public Transform currentWayPoint,nextWayPoint;
	public int position,currentLap;
	public float distanceToNextPoint;
	public bool finished;
	public string finishTime;
	void Start () {
		currentWayPoint = GameObject.Find ("Wall").transform.Find ("1a");
		nextWayPoint = currentWayPoint.GetComponent<NodeA> ().next;
		finishTime="0";

	}

	void Update () {

	}

	public float getDistanceToNextPoint(){
		distanceToNextPoint = Vector3.Distance (nextWayPoint.position, transform.position);
		return distanceToNextPoint;
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
