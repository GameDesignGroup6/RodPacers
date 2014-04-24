using UnityEngine;
using System.Collections;

public class CameraAnimator : MonoBehaviour {
	public CameraAnimationNode node;//the node we are moving towards
	public float baseSpeed;//units: m/s
	public bool fixedSpeed;//ignore the node's curve
	private Quaternion oldRot;
//	private Vector3 oldPos;
	private Transform trans;
	private float distanceToNextNode;
//	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		trans = transform;
		oldRot = trans.rotation;
//		oldPos = trans.position;
		//the camera's initial position and rotation form an initial node
		distanceToNextNode = Vector3.Distance(trans.position,node.transform.position);		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown){
			stop();
			return;
		}
		float lerp = 1f-Vector3.Distance(trans.position,node.transform.position)/distanceToNextNode;
		float curSpeed=baseSpeed;
		if(!fixedSpeed&&node.useAnimationCurve){
			curSpeed*=node.curve.Evaluate(lerp);
			curSpeed = Mathf.Max(curSpeed,0.001f);//the camera must be moving at all times!
		}
		trans.position = Vector3.MoveTowards(trans.position,node.transform.position,curSpeed*Time.deltaTime);
		trans.rotation = Quaternion.Slerp (oldRot,node.transform.rotation,lerp);
		if(trans.position.Equals(node.transform.position)){
//			velocity = Vector3.zero;
//			oldPos = node.transform.position;
			oldRot = node.transform.rotation;
			if(node.HasNext){
				distanceToNextNode = node.DistanceToNextNode;
				node = node.nextNode;
				if(node.instantFade){
					trans.position = node.transform.position;
					trans.rotation = node.transform.rotation;
				}
			}else{
				stop();
			}
		}
	}
	public void stop(){
		Destroy(gameObject);
		
		Application.LoadLevel ("Test1");
	}
}
