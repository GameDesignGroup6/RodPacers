using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody),typeof(RigidbodyInfo))]
public class WobbleGenerator : MonoBehaviour {
	private Rigidbody body;
	private RigidbodyInfo bodyInfo;
	public InputManager manager;
	public float forceMiltiplier=1f,torqueMultiplier=1f;
	public float velocityThreshold = 1f;
	public float boostMultiplier = 20f;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
		bodyInfo = GetComponent<RigidbodyInfo>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		bool force = false;
		if(manager!=null)force = manager.bothTriggersPressed();
		if(bodyInfo.Velocity>velocityThreshold && !force)return;
		body.AddForce(Random.onUnitSphere*forceMiltiplier*(force?boostMultiplier:1f));
		body.AddTorque(Random.onUnitSphere*torqueMultiplier*(force?boostMultiplier:1f));
	}
}
