using UnityEngine;
using System.Collections;

//cauese the engines to automatically turn when tilted
public class EngineAutoTiltTurn : MonoBehaviour {
	public Rigidbody leftEngine;
	public Rigidbody rightEngine;
	public float keng;
	public float kpod;
	public float kreturnToLevel;
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
	
	// Update is called once per frame
	void FixedUpdate () {
//		Vector3 leftAngle = leftTransform.localEulerAngles;
//		Vector3 rightAngle = rightTransform.localEulerAngles;
//		leftAngle.y=0;
//		rightAngle.y=0;
//		leftTransform.localEulerAngles=leftAngle;
//		rightTransform.localEulerAngles=rightAngle;
		//doesnt work :(



		float heightDelta = rightTransform.position.y-leftTransform.position.y;
		if(Mathf.Abs(heightDelta)<threshold)return;
		leftEngine.AddRelativeTorque(0f,0f,keng*heightDelta);
		rightEngine.AddRelativeTorque(0f,0f,keng*heightDelta);
		podRigidbody.AddRelativeTorque(0f,0f,kpod*heightDelta);
//		leftEngine.AddRelativeForce(Vector3.back*heightDelta*kreturnToLevel);
//		rightEngine.AddRelativeForce(Vector3.back*heightDelta*kreturnToLevel);
	}
}
