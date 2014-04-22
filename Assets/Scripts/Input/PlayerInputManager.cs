using UnityEngine;
using System.Collections;

public class PlayerInputManager : InputManager {
	public int playerNumber;

	public override float getLeftTrigger(){
		float leftTrigger = Input.GetAxis("LeftTrigger" + playerNumber);
		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer) {
			leftTrigger = (leftTrigger +1)/2;
		}
		return leftTrigger;
	}
	public override float getRightTrigger(){
		float rightTrigger = Input.GetAxis("RightTrigger" + playerNumber);
		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer) {
			rightTrigger = (rightTrigger + 1)/2;
		}
		return rightTrigger;
	}
	public override float getThrottle(){
		return Input.GetAxis("Throttle"+playerNumber);
	}
}
