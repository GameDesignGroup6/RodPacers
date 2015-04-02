using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(GUIText))]
public class TimeHUD : MonoBehaviour {

	// Position the text
	void Start () {
		transform.position = Vector3.up;
		GetComponent<GUIText>().alignment = TextAlignment.Left;
		GetComponent<GUIText>().anchor = TextAnchor.UpperLeft;
		GetComponent<GUIText>().richText = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		// Steven wants it to be able to disappear
		if(Input.GetKey(KeyCode.LeftShift)&&Input.GetKeyDown(KeyCode.H)){
			GetComponent<GUIText>().enabled = !GetComponent<GUIText>().enabled;
		}

		// Split it into each digit
		GetComponent<GUIText>().text = "<color=yellow>" + (int)(Time.timeSinceLevelLoad/60) + ":" + (int)((Time.timeSinceLevelLoad%60)/10)
			+ (int)((Time.timeSinceLevelLoad%60)%10) + ":" + (int)(Time.timeSinceLevelLoad%1 * 10) + (int)(Time.timeSinceLevelLoad%.1 * 100)
				+ (int)(Time.timeSinceLevelLoad%.01 * 1000) + "</color>" ;
	}
}