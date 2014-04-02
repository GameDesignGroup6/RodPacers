using UnityEngine;
using System.Collections;
[RequireComponent(typeof(GUIText))]
public class VelocityHUD : MonoBehaviour {
	public VelocityDisplay[] velocities;


	[System.Serializable]
	public class VelocityDisplay{
		public RigidbodyInfo body;
		public string displayName;
	}


	// Use this for initialization
	void Start () {
		transform.position = Vector3.up;
		guiText.alignment = TextAlignment.Left;
		guiText.anchor = TextAnchor.UpperLeft;
		guiText.richText = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		string s = "";
		for(int i = 0; i<velocities.Length;i++){
			s+="<color=blue>"+velocities[i].displayName+"</color>: ";
			s+=velocities[i].body.Velocity+" m/s\n";
		}
		guiText.text = s;
	}
}
