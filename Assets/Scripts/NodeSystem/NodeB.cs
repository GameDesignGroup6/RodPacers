using UnityEngine;
using System.Collections;

public class NodeB : MonoBehaviour {
	public Transform nodeNearest;
	public bool startPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider collision) {
				if (collision.gameObject.tag == "Player") {
				if (startPoint) {
				if (collision.gameObject.GetComponent<PlayerNode> ().currentLap == 0) { //first lap
					collision.gameObject.GetComponent<PlayerNode> ().currentLap++;
					return;
				} else if (collision.gameObject.GetComponent<PlayerNode> ().currentLap ==  (GameObject.Find ("rank").GetComponent<Rank>().totalLap) && collision.gameObject.GetComponent<PlayerNode> ().currentWayPoint.name=="35a")
					collision.gameObject.GetComponent<PlayerNode> ().finish ();
				else if (collision.gameObject.GetComponent<PlayerNode> ().currentWayPoint == nodeNearest) //go backward, decrease lap
					collision.gameObject.GetComponent<PlayerNode> ().currentLap--;
				else
					collision.gameObject.GetComponent<PlayerNode> ().currentLap++;
			}
			if (collision.gameObject.GetComponent<PlayerNode> ().currentWayPoint == nodeNearest) {
				collision.gameObject.GetComponent<PlayerNode> ().currentWayPoint = nodeNearest.GetComponent<NodeA> ().previous;
				collision.gameObject.GetComponent<PlayerNode> ().nextWayPoint = nodeNearest;
				//	Debug.Log ("BBBBBBBBBB"+collision.gameObject.GetComponent<PlayerNode> ().currentWayPoint);
			}
		}


		}

}
