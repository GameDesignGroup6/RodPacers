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
		rgb = GetComponent<Rigidbody>();
	}
//	void Update(){
//		DebugHUD.setValue(gameObject.transform.parent.name+"/"+name+" velocity",curVelocity);
//	}
	void FixedUpdate () {
		if(rgb==null)rgb=GetComponent<Rigidbody>();
		curVelocity = Vector3.Magnitude(rgb.velocity);
	}
}
