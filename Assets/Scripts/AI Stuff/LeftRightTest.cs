/*
 * majority of LeftRightTest code courtesy of HigherScripting authority from the Unity forums.
 * Found at: "http://forum.unity3d.com/threads/31420-Left-Right-test-function"
 */ 
using UnityEngine;
using System.Collections;

public class LeftRightTest : MonoBehaviour {

	public Transform target;
	public float dirNum;
	NodeRespawn spawn;

	void Start() {
		target = GameObject.Find("Node1").transform;
		spawn = GetComponent<NodeRespawn>();
	}

	void Update () {
		Vector3 heading = target.position - transform.position;
		dirNum = AngleDir(transform.forward, heading, transform.up);
	}

	public void ChangeNode() {
		target = spawn.nodeTransform;
	}
	
	float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		float dir = Vector3.Dot(perp, up);
		if (dir > 0f) {
			//Debug.Log ("Going Right!");
			return 1f;
		} else if (dir < 0f) {
			//Debug.Log ("Going Left!");
			return -1f;
		} else {
			//Debug.Log ("Going Straight!");
			return 0f;
		}
	}
	
}
