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
		Matrix4x4 mat = GetComponent<Camera>().projectionMatrix;
		mat[0,2] = horizontal;
		mat[1,2] = vertical;
		GetComponent<Camera>().projectionMatrix = mat;
	}
	void OnDisable(){
		GetComponent<Camera>().ResetProjectionMatrix();
	}
	void OnEnable(){
		OnValidate();
	}
}
