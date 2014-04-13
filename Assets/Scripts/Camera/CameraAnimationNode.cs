using UnityEngine;
using System.Collections;

public class CameraAnimationNode : MonoBehaviour {
	public float transitionTime;//the time it should take to transition to this node;
	public CameraAnimationNode nextNode;
	public float holdTime;//how long the camera should sit here once it reaches this node.
	public bool HasNext{
		get{return nextNode!=null;}
	}
	public bool useAnimationCurve;//use the provided curve, else use a linear lerp
	public AnimationCurve curve;

	/**
	 * returns the value to be passed into lerp or slerp given the time since the transition to this node started
	 */
	public float getLerpForTime(float time){
		if(time>=transitionTime)return 1.0f;
		if(transitionTime==0.0f)return 1.0f;
		float normalized = time/transitionTime;
		if(useAnimationCurve){
			return curve.Evaluate(normalized);
		}else{
			return normalized;
		}
	}
	/**
	 * returns true if at the given time we should move on to the next node
	 */
	public bool shouldTransitionToNext(float time){
		return (time>=(transitionTime+holdTime));
	}

}