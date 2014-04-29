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
			PlayerNode playerNode=collision.gameObject.GetComponent<PlayerNode> ();
			if (startPoint) {
				if (playerNode.currentLap == 0) { //first lap
					playerNode.currentLap++;
					return;
				} else if (playerNode.currentLap ==  (GameObject.Find ("Rank").GetComponent<Rank>().totalLap) && playerNode.currentWayPoint.name=="35a")
					playerNode.finish ();
				else if (playerNode.currentWayPoint == nodeNearest) //go backward, decrease lap
					playerNode.currentLap--;
				else
					playerNode.currentLap++;
			}
			if (playerNode.currentWayPoint == nodeNearest) {
				playerNode.currentWayPoint = nodeNearest.GetComponent<NodeA> ().previous;
				playerNode.nextWayPoint = nodeNearest;
			}
		}


		}

}
