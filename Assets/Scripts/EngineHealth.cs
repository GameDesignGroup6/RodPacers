using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class EngineHealth : MonoBehaviour {
	public float maxHealth = 1000f;
	public EnginePair enginePair;
	private float curHealth;
	public float Health{
		get{return curHealth;}
	}
	public float angleThreshold = 30f;
	private Transform left,right;

	// Use this for initialization
	void Start () {
		curHealth = maxHealth;
		left = enginePair.left.body.transform;
		right = enginePair.right.body.transform;
	}
	void OnCollisionStay(Collision col){
		Vector3 velocity = col.relativeVelocity;
		Vector3 normal = col.contacts[0].normal;
		float damage = Vector3.Dot(normal,velocity);
		curHealth-=Mathf.Abs(damage);
	}
	
	// Update is called once per frame
	void Update () {
		DebugHUD.setValue(name+" health",curHealth);
	}

	void FixedUpdate(){
		if(enginePair.EnginesSwitched)curHealth-=5f;

		float angleDelta = Vector3.Angle(left.up,right.up);

		if(angleDelta>angleThreshold)curHealth-=1;
		DebugHUD.setValue(name+" angleDelta",angleDelta);
	}
}
