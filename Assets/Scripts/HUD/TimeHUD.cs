using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(GUIText))]
public class TimeHUD : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = Vector3.up;
		guiText.alignment = TextAlignment.Left;
		guiText.anchor = TextAnchor.UpperLeft;
		guiText.richText = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "<color=yellow>" + (int)(Time.timeSinceLevelLoad/60) + ":" + (int)((Time.timeSinceLevelLoad%60)/10)
			+ (int)((Time.timeSinceLevelLoad%60)%10) + ":" + (int)(Time.timeSinceLevelLoad%1 * 10) + (int)(Time.timeSinceLevelLoad%.1 * 100)
				+ (int)(Time.timeSinceLevelLoad%.01 * 1000) + "</color>" ;
	}
}