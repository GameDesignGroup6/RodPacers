using UnityEngine;
using System.Collections;
/**
 * This script makes an object spin and bob
 */
public class bouncySpinnyCubeScript : MonoBehaviour {
	private Vector3 initPos;//inital position, where the sine function is centered

	public float bobHeight;//how high should we bob?
	public float bobRate;//how fast should we bob?
	public Vector3 spinRate;//how fast should we spin in each direction

	private float offset = 0f;//random offset for the bob of each instance
	public bool useOffset = true;
	

	// Use this for initialization
	void Start () {
		initPos = transform.localPosition;
		if(useOffset)
		offset = Random.Range(0f,360f);
//		initRot = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		float y = initPos.y+Mathf.Sin(Time.time*bobRate+offset)*bobHeight;
		Vector3 oldPos = transform.localPosition;
		oldPos.y = y;
		transform.localPosition = oldPos;
		Vector3 newAngle = transform.localEulerAngles;
		newAngle.x = Mathf.Repeat(Time.time*spinRate.x+offset,360);
		newAngle.y = Mathf.Repeat(Time.time*spinRate.y+offset,360);
		newAngle.z = Mathf.Repeat(Time.time*spinRate.z+offset,360);
		transform.localEulerAngles = newAngle;
	}
}
