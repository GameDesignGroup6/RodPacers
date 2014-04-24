using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Collider))]
public class HurtZone : MonoBehaviour {
	public float damage;
	void OnTriggerStay(Collider other){
		EngineHealth health = other.gameObject.GetComponent<EngineHealth>();
		if(health==null)return;
		health.Hurt(damage);
	}
}
