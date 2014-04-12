using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnginePair))]
public class FixedEnginePodConnector : MonoBehaviour {
	public Engine left,right;
	private Transform pod;
	private Vector3 podOffsetLeft,podOffsetRight;//the local position of the pod as if it were a child of the respective engine
	private LineRenderer leftRenderer,rightRenderer;
	public Transform leftMount,rightMount;
	// Use this for initialization
	void Start () {
		pod = transform;

		podOffsetLeft = left.EngineTransform.InverseTransformPoint(pod.position);
		podOffsetRight = right.EngineTransform.InverseTransformPoint(pod.position);
		if(rigidbody){rigidbody.isKinematic = true;}
		HoverScript hs = GetComponent<HoverScript>();
		if(hs)hs.enabled = false;

		leftRenderer = leftMount.GetComponent<LineRenderer>();
		rightRenderer = rightMount.GetComponent<LineRenderer>();
		if(leftRenderer)leftRenderer.SetVertexCount(2);
		if(rightRenderer)rightRenderer.SetVertexCount(2);
	}

	void LateUpdate () {
		Vector3 podLeftPos = left.EngineTransform.TransformPoint(podOffsetLeft);
		Vector3 podRightPos = right.EngineTransform.TransformPoint(podOffsetRight);
		pod.position = (podLeftPos+podRightPos)/2f;

		Vector3 midpoint = (left.TransformPosition+right.TransformPosition)/2f;
		pod.rotation = Quaternion.Lerp (left.EngineTransform.rotation,right.EngineTransform.rotation,0.5f);
		pod.Rotate(-90f,0f,0f,Space.Self);


//		pod.up = (left.EngineTransform.forward+right.EngineTransform.forward)/(-2f);
	
//		pod.LookAt (midpoint);
		
//		Vector3 deltaVector = Vector3.Normalize(right.TransformPosition-midpoint);
		Vector3 transformedPoint = right.EngineTransform.InverseTransformPoint(left.TransformPosition);
		float angle =  Vector3.Angle (Vector3.left,transformedPoint);
		if(transformedPoint.z<0)angle = -angle;

		Vector3 temp = pod.localEulerAngles;
		temp.z = angle;
		pod.localEulerAngles = temp;
		
		if(leftRenderer){
			leftRenderer.SetPosition(0,leftMount.position);
			leftRenderer.SetPosition(1,left.TransformPosition);
		}
		if(rightRenderer){
			rightRenderer.SetPosition(0,rightMount.position);
			rightRenderer.SetPosition(1,right.TransformPosition);
		}
		DebugHUD.setValue("LeftStick",Input.GetAxis("LeftStickVert"));
		
	}
}
