using UnityEngine;
using System.Collections;

public class NodeA : MonoBehaviour {
	public Transform next,previous;
	public int rank;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.tag=="Player"){
			PlayerNode playerNode=collision.gameObject.GetComponent<PlayerNode> ();
			if (playerNode.currentWayPoint!=transform){
				playerNode.currentWayPoint = transform;
				playerNode.nextWayPoint = next;
			}
		}
	}
}
