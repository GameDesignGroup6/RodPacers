using UnityEngine;
using System.Collections;

public class ForwardBackSimulator : MonoBehaviour {

	public bool backwards = false;

	void OnCollisionEnter (Collision collision) {
		if (collision.collider.tag != "Player!" && collision.collider.tag != "Engine") {
			backwards = true;
			StartCoroutine(Wait ());
		}
	}
		
	IEnumerator Wait() {
		yield return new WaitForSeconds(2f);
		backwards = false;
	}
}
