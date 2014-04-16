using UnityEngine;
using System.Collections;

public class CameraAnimationNode : MonoBehaviour {
	public bool instantFade = false;
	public CameraAnimationNode nextNode;
	public bool HasNext{
		get{return nextNode!=null;}
	}
	public bool useAnimationCurve;//use the provided curve, else use a linear lerp
	public AnimationCurve curve;
	private float distanceToNextNode = 0f;
	public float DistanceToNextNode{
		get{return distanceToNextNode;}
	}

	void Awake(){
		if(HasNext){
			distanceToNextNode = Vector3.Distance(transform.position,nextNode.transform.position);
		}
	}
	

}