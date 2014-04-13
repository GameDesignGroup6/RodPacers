using UnityEngine;
using System.Collections;

public class CameraAnimator : MonoBehaviour {
	public CameraAnimationNode node;
	private float time = 0f;
	private Quaternion oldRot;
	private Vector3 oldPos;
	private Transform trans;

	// Use this for initialization
	void Start () {
		trans = transform;
		oldRot = trans.rotation;
		oldPos = trans.position;
	}
	
	// Update is called once per frame
	void Update () {
		time+=Time.deltaTime;
		float lerp = node.getLerpForTime(time);
		trans.position = Vector3.Lerp (oldPos,node.transform.position,lerp);
		trans.rotation = Quaternion.Slerp (oldRot,node.transform.rotation,lerp);
		if(node.shouldTransitionToNext(time)){
			time = 0f;
			oldPos = node.transform.position;
			oldRot = node.transform.rotation;
			if(node.HasNext){
				node = node.nextNode;
			}else{
				Debug.Log ("Done with camera stuff!");
			}
		}
	}
}
