using UnityEngine;
using System.Collections;

//cauese the engines to automatically turn when tilted
public class EngineAutoTiltTurn : MonoBehaviour {
	public Rigidbody leftEngine;
	public Rigidbody rightEngine;
	public float keng;
	public float kpod;
	public float threshold;

	private Transform leftTransform;
	private Transform rightTransform;
	private Rigidbody podRigidbody;
	// Use this for initialization
	void Start () {
		leftTransform = leftEngine.transform;
		rightTransform = rightEngine.transform;
		podRigidbody = rigidbody;
	}
	void FixedUpdate () {
		float heightDelta = rightTransform.position.y-leftTransform.position.y;
		DebugHUD.setValue("Engine Height Delta",heightDelta);
		if(Mathf.Abs(heightDelta)<threshold)return;
		leftEngine.AddRelativeTorque(0f,0f,keng*heightDelta);
		rightEngine.AddRelativeTorque(0f,0f,keng*heightDelta);
		podRigidbody.AddRelativeTorque(0f,0f,kpod*heightDelta);
	}
}
