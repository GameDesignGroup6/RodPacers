using UnityEngine;
using System.Collections;

/**
chock  (tʃɒk)
 
— n
1. 	a block or wedge of wood used to prevent the sliding or rolling of a heavy object 

keeps hovering objects bound to a point
*/

[RequireComponent(typeof(HoverScript))]
public class HoverChock : MonoBehaviour {
	//waits until the hovering object has reached it's target height, then holds it in place
	public bool waitUntilTargetHeight = true;
	public bool workInYDirection = false;
	public bool holdToStartPos = true;
	public float k = 1f;

	private HoverScript hoverScript;
	private Rigidbody rgb;
	private Transform trans;
	private bool running;
	public bool isActive{
		get{
			return running;
		}
		set{
			if(value){
				if(!holdToStartPos)targetPos = trans.position;
				if(enableScriptOnActivate&&scriptToActivate!=null)scriptToActivate.enabled = true;
			}else{
				DebugHUD.setValue("HoverChock: "+name,"Not Active");
			}
			running = value;
		}
	}
	public bool enableScriptOnActivate;
	public MonoBehaviour scriptToActivate;



	private Vector3 targetPos;
	
	void Awake () {
		hoverScript = GetComponent<HoverScript>();
		rgb = rigidbody;
		trans = transform;
	}
	void Start(){
		if(holdToStartPos)targetPos = trans.position;
		isActive = !waitUntilTargetHeight;
	}
	

	// Update is called once per frame
	void FixedUpdate () {
		DebugHUD.setValue("HoverChock: "+name,"Not Active");
		if(!isActive&&!waitUntilTargetHeight)return;
		if(!isActive&&waitUntilTargetHeight){
			if(Mathf.Abs(hoverScript.AverageHoverHeight-hoverScript.targetHeight)<0.05f){
				isActive = true;
			}else{return;}
		}
		Vector3 targetPosCopy = targetPos;
		Vector3 curPos = trans.position;
		if(!workInYDirection){
			targetPosCopy.y=0;
			curPos.y = 0;
		}
		float magnitude = Vector3.Distance(targetPosCopy,curPos)*k;
		DebugHUD.setValue("HoverChock: "+name,"Force: "+magnitude);
		Vector3 force = (targetPosCopy-curPos)*magnitude;
		rgb.AddForce(force);
		Debug.DrawRay(trans.position,force,Color.magenta);

	}
}
