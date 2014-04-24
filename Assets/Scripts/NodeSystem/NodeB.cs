using UnityEngine;
using System.Collections;

public class NodeB : MonoBehaviour {
	public Transform nodeNearest;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider collision) {
				if (collision.gameObject.tag == "Pod")
				if (collision.gameObject.GetComponent<PlayerNode> ().currentWayPoint == nodeNearest) {
						collision.gameObject.GetComponent<PlayerNode> ().currentWayPoint = nodeNearest.GetComponent<NodeA> ().previous;
						collision.gameObject.GetComponent<PlayerNode> ().nextWayPoint = nodeNearest;
			Debug.Log ("BBBBBBBBBB"+collision.gameObject.GetComponent<PlayerNode> ().currentWayPoint);
				}

		}

}
