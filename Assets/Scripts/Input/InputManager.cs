using UnityEngine;
using System.Collections;

public abstract class InputManager : MonoBehaviour {
	public abstract float getLeftTrigger();
	public abstract float getRightTrigger();
	public bool bothTriggersPressed(){
		return getLeftTrigger()>=0.1f && getRightTrigger()>=0.1f;
	}
	public abstract float getThrottle();
}
