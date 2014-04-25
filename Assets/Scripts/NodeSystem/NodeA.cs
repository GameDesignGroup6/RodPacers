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
		if (collision.gameObject.tag=="Player")
			//if (!(collision.gameObject.GetComponent<PlayerNode> ().currentWayPoint.name=="1a" && name!="3a"))
			if (collision.gameObject.GetComponent<PlayerNode> ().currentWayPoint!=transform){
				Debug.Log (transform+"AAAAA");
				collision.gameObject.GetComponent<PlayerNode> ().currentWayPoint = transform;
				collision.gameObject.GetComponent<PlayerNode> ().nextWayPoint = next;
		}
	}
}
