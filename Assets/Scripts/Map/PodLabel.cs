using UnityEngine;
using System.Collections;

/**
 *Attach this script to the cube inside the pod
 */
public class PodLabel : MonoBehaviour {


	public int playerNum;
	public GUIText label;


	public Transform pod;
	public float maxDist;

	public Camera[] podCams;
	// Use this for initialization
	void Start () {
		playerNum = int.Parse(transform.root.name.Substring(transform.root.name.Length-1));
		pod = transform.parent;
		label = transform.root.GetComponentInChildren<GUIText>();
		maxDist = 100;
		int i = 0;
		foreach (Camera cam in Camera.allCameras){
			if ((cam.name.Substring(0,6) == "Camera")&&(cam.name.Substring(6) != ""+ playerNum)){
				podCams[i] = cam;
				i++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i<podCams.Length; i++){

			if (nearBy (podCams[i])){
				label.text = "Player " + playerNum;
				label.transform.position = podCams[i].WorldToViewportPoint(pod.transform.position + Vector3.up);
			}
		}
	}

	bool nearBy (Camera podCam){
		if (Vector3.Distance(podCam.transform.position, pod.transform.position) < maxDist)
			return true;
		else return false;
	}

	void OnWillRenderObject(){
		Camera cam = Camera.current;
		if (cam.name == "MiniMap" || cam.name == "SceneCamera")
			return;
		label.text = "Player " + playerNum;
		label.transform.position = cam.WorldToViewportPoint(pod.transform.position + Vector3.up);
		Debug.Log ("I am " + cam.name + "and I am viewing " + transform.name);

	}

}
