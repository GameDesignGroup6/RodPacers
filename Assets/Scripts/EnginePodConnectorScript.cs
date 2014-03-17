using UnityEngine;
using System.Collections;

public class EnginePodConnectorScript : MonoBehaviour {
	public float maxDist;
	public Transform rightEngine,leftEngine,rightMount,leftMount;
	public float k;
	private float targetDist;
	private float targetCrossDist;
//	private Transform trans;
	private Rigidbody rb;
	
	private LineRenderer leftRenderer,rightRenderer;


	// Use this for initialization
	void Start () {
//		trans = transform;//GameObject.transform is just an alias for GetComponent<Transform>()!
		rb = rigidbody;
		targetDist = (Vector3.Distance(rightMount.position,rightEngine.position)+Vector3.Distance(leftMount.position,leftEngine.position))/2.0f;
		targetCrossDist = (Vector3.Distance(rightMount.position,leftEngine.position)+Vector3.Distance(leftMount.position,rightEngine.position))/2.0f;
		leftRenderer = leftMount.GetComponent<LineRenderer>();
		rightRenderer = rightMount.GetComponent<LineRenderer>();
		if(leftRenderer)leftRenderer.SetVertexCount(2);
		if(rightRenderer)rightRenderer.SetVertexCount(2);

	}
	void Update(){
		UpdateStraight();
		UpdateCross();
	}

	private void UpdateStraight () {
		float leftDist = targetDist-Vector3.Distance(leftMount.position,leftEngine.position);
		Vector3 leftForce = (leftEngine.position-leftMount.position)*k*leftDist;//wait, this ins't a normalized vector, so the length is already included...?
		rb.AddForceAtPosition(leftForce,leftMount.position);
		if(leftRenderer){
			leftRenderer.SetPosition(0,leftMount.position);
			leftRenderer.SetPosition(1,leftEngine.position);
		}
		Debug.DrawRay(leftMount.position,leftForce,Color.blue);

		float rightDist = targetDist-Vector3.Distance(rightMount.position,rightEngine.position);
		Vector3 rightForce = (rightEngine.position-rightMount.position)*k*rightDist;
		rb.AddForceAtPosition(rightForce,rightMount.position);
		if(rightRenderer){
			rightRenderer.SetPosition(0,rightMount.position);
			rightRenderer.SetPosition(1,rightEngine.position);
		}
		Debug.DrawRay(rightMount.position,rightForce,Color.blue);

	}
	private void UpdateCross () {
		float leftDist = targetCrossDist-Vector3.Distance(leftMount.position,rightEngine.position);
		Vector3 leftForce = (rightEngine.position-leftMount.position)*k*leftDist;//wait, this ins't a normalized vector, so the length is already included...?
		rb.AddForceAtPosition(leftForce,leftMount.position);
		Debug.DrawRay(leftMount.position,leftForce,Color.red);
		
		float rightDist = targetCrossDist-Vector3.Distance(rightMount.position,leftEngine.position);
		Vector3 rightForce = (leftEngine.position-rightMount.position)*k*rightDist;
		rb.AddForceAtPosition(rightForce,rightMount.position);
		Debug.DrawRay(rightMount.position,rightForce,Color.red);
		
	}
}
