using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyInfo : MonoBehaviour {
	private float curVelocity;
	public float Velocity{
		get{return curVelocity;}
	}
	private Rigidbody rgb;
	// Use this for initialization
	void Start () {
		rgb = rigidbody;
	}

	void FixedUpdate () {
		if(rgb==null)rgb=rigidbody;
		curVelocity = Vector3.Magnitude(rgb.velocity);
	}
}
