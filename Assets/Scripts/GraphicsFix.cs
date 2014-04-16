using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class GraphicsFix : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = rigidbody.position;
		transform.rotation = rigidbody.rotation;
	}
}
