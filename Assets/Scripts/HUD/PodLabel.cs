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

	public int initialFontSize = 14;
	public float fontScaling = 1f;
	// Use this for initialization
	void Start () {
		playerNum = int.Parse(transform.root.name.Substring(transform.root.name.Length-1));
		pod = transform.parent;
		label = transform.root.GetComponentInChildren<GUIText>();
		label.fontSize = initialFontSize;
		label.fontStyle = FontStyle.Bold;
		label.color = Color.red;
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
			if (nearby (podCams[i])){
				label.text = "Player " + playerNum;
				label.fontSize = (int)(initialFontSize * fontScaling);
				label.transform.position = podCams[i].WorldToViewportPoint(pod.transform.position + 3*Vector3.up);
				scaleFont (podCams[i]);
				//Invoke("scaleFont", 1f);
			}
		}
	}

	bool nearby (Camera podCam){
		//doing this since we don't have to be extremely precise with the max distance where the label is visible.
		Vector3 difference = podCam.transform.position - pod.transform.position;
		if (difference.x <maxDist && difference.z <maxDist)
			return true;
		else return false;
	}
	void scaleFont (Camera podCam){
		Vector3 difference = podCam.transform.position - pod.transform.position;
		fontScaling = 1f - (difference.sqrMagnitude / Mathf.Pow(1.41f * maxDist,2));
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
