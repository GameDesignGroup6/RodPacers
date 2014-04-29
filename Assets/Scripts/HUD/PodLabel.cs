using UnityEngine;
using System.Collections;

/**
 *Attach this script to the cube inside the pod
 */
public class PodLabel : MonoBehaviour {
	public int playerNum;
	public Transform pod;
	public float maxDist;
	public Camera[] podCams;
	public GUIText[] podLabels;
	public int initialFontSize = 14;
	public float fontScaling = 1f;

	// Use this for initialization
	void Start () {
		podCams = new Camera[4];
		podLabels = new GUIText[4];
		maxDist = 100;
		playerNum = int.Parse(transform.root.name.Substring(transform.root.name.Length-1));
		pod = transform.parent;
		foreach (Camera cam in Camera.allCameras){
			if ((cam.name.Substring(0,6) == "Camera")&&(cam.name.Substring(6) != ""+ playerNum)){
				podCams[int.Parse(cam.name.Substring (6)) -1] = cam;
			}
		}
		foreach (GUIText label in transform.root.GetComponentsInChildren<GUIText>()){
			if ((label.name.Substring (0, "Label".Length) == "Label")&&(label.name.Substring("Label".Length) != ""+ playerNum)){
				label.fontSize = initialFontSize;
				label.fontStyle = FontStyle.Bold;
				label.color = Color.red;
				podLabels[int.Parse (label.name.Substring("Label".Length))- 1] = label;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i<podCams.Length; i++){
			if (podCams[i] != null && nearby (podCams[i])){
				scaleFont (podCams[i]);
				podLabels[i].text = "Player " + playerNum;
				podLabels[i].fontSize = (int)(initialFontSize * fontScaling);
				podLabels[i].transform.position = podCams[i].WorldToViewportPoint(pod.transform.position + 3*Vector3.up);
			}
		}
	}

	bool nearby (Camera podCam){
		//doing this since we don't have to be extremely precise with the max distance where the label is visible.
		Vector3 difference = podCam.transform.position - pod.transform.position;
		if (Mathf.Abs (difference.x) <maxDist && Mathf.Abs (difference.z) <maxDist)
			return true;
		else return false;
	}

	void scaleFont (Camera podCam){
		Vector3 difference = podCam.transform.position - pod.transform.position;
		fontScaling = 1f - (difference.sqrMagnitude / Mathf.Pow(1.41f * maxDist,2));
	}
}
