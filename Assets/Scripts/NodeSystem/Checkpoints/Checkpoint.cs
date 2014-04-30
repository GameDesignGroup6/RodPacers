using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Collider))]
public class Checkpoint : MonoBehaviour {
	public int number;
	public Checkpoint next;
	void Start(){
		collider.isTrigger = true;
	}
	void OnTriggerEnter(Collider other){
		SpawnManager manager = other.transform.parent.GetComponent<SpawnManager>();
		if(manager!=null)manager.updateCheckpoint(this);
		NodeRank rank = other.transform.parent.GetComponent<NodeRank>();
		if(rank!=null)rank.curCheckpoint = this;
	}
}
