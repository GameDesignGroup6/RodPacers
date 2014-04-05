using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class CameraExtender : MonoBehaviour {
	public float horizontal;
	public float vertical;
	// Use this for initialization
	void Start () {
		OnValidate();
	}
	void OnValidate(){
		Matrix4x4 mat = camera.projectionMatrix;
		mat[0,2] = horizontal;
		mat[1,2] = vertical;
		camera.projectionMatrix = mat;
	}
	void OnDisable(){
		camera.ResetProjectionMatrix();
	}
	void OnEnable(){
		OnValidate();
	}
}
