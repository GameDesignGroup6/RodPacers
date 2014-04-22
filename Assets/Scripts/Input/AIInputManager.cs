using UnityEngine;
using System.Collections;

public class AIInputManager : InputManager {
	public override float getLeftTrigger(){
		return 0;
	}
	public override float getRightTrigger(){
		return 0;
	}
	public override float getThrottle(){
		return 0;
	}
}
