using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Collider))]
public class Checkpoint : MonoBehaviour {
	void Start(){
		collider.isTrigger = true;
	}
	void OnTriggerEnter(Collider other){
		SpawnManager manager = other.transform.parent.GetComponent<SpawnManager>();
		if(manager==null)return;
		manager.updateCheckpoint(this.transform);
	}
}
