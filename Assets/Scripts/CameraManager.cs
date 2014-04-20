using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
	public Camera[] cameras;
	public FollowMode[] follows;
	public Vector3[] offsets;
	public Transform followObject;



	public enum FollowMode{NONE,POSITION_ONLY,LOOKAT,ATTATCH};
	private int currentCamera = 0;

//	public class CameraInfo{
//		public Camera camera{get; set;}
//		public FollowMode mode{get; set;}
//		public Vector3 offset{get; set;}
//	}
//	public CameraInfo[] camerasinfo;

	// Use this for initialization
	void Start () {
//		GameEventManager.GameStart+=switchToCurrentCamera;//omit this line to make this script fully generic
		switchToCurrentCamera();
	}

	// Update is called once per frame 
	void LateUpdate () {
		for(int i = 0; i<cameras.Length;i++){
			if(follows[i]==FollowMode.NONE)continue;
			if(follows[i]==FollowMode.POSITION_ONLY||follows[i]==FollowMode.ATTATCH){
				Vector3 lp = followObject.localPosition;
				lp+=offsets[i];
				cameras[i].transform.localPosition = lp;
			}
			if(follows[i]==FollowMode.LOOKAT){
				cameras[i].transform.LookAt(followObject.localPosition);
			}

		}

		if(Input.GetKeyDown("f1")){
			nextCamera ();
		}
	}
	public void switchToCurrentCamera(){
		for(int i = 0; i<cameras.Length;i++){
			cameras[i].enabled = false;
		}
		cameras[currentCamera].enabled = true;
	}
	public void switchToCamera(int camNum){
		for(int i = 0; i<cameras.Length;i++){
			cameras[i].enabled = false;
		}
		cameras[camNum].enabled = true;
	}
	public void nextCamera(){
		currentCamera++;
		if(currentCamera>=cameras.Length)currentCamera=0;
		switchToCurrentCamera();
	}
}
