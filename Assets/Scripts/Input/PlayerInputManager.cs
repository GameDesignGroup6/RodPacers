using UnityEngine;
using System.Collections;

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
using XInputDotNetPure;
#endif

[RequireComponent(typeof(NodeRespawn))]
public class PlayerInputManager : InputManager {
	public int playerNumber;

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
    private bool pressedLastFrame = false;
#endif

	public override float getLeftTrigger(){
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        return GamePad.GetState((PlayerIndex)(playerNumber-1)).Triggers.Left;
#else
		float leftTrigger = Input.GetAxis("LeftTrigger" + playerNumber);
		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer) {
			leftTrigger = (leftTrigger +1)/2;
		}
		return leftTrigger;
#endif
	}
	public override float getRightTrigger(){
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        return GamePad.GetState((PlayerIndex)(playerNumber - 1)).Triggers.Right;
#else
		float rightTrigger = Input.GetAxis("RightTrigger" + playerNumber);
		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer) {
			rightTrigger = (rightTrigger + 1)/2;
		}
		return rightTrigger;
#endif
	}
	public override float getThrottle(){
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        float val = 0f;
        if (GamePad.GetState((PlayerIndex)(playerNumber - 1)).Buttons.A == ButtonState.Pressed) val += 1.0f;
        if (GamePad.GetState((PlayerIndex)(playerNumber - 1)).Buttons.B == ButtonState.Pressed) val -= 1.0f;
        return val;
#else
		return Input.GetAxis("Throttle"+playerNumber);
#endif
	}
	void Update(){
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        //xinput doesn't have a "ButtonDown", we need to do it manually
        bool pressedThisFrame = GamePad.GetState((PlayerIndex)(playerNumber - 1)).Buttons.Y == ButtonState.Pressed;
        if (pressedThisFrame && !pressedLastFrame) {
            respawnPlayer();
            pressedLastFrame = true;
        }
        if (!pressedThisFrame) pressedLastFrame = false;
#else
        if (Input.GetButtonDown("Respawn" + playerNumber)) {
            respawnPlayer();
        }
#endif
	}

    //AAEE: moved so that it can be changed more easily
    private void respawnPlayer() {
        transform.parent.GetComponent<SpawnManager>().respawnAtLastCheckpoint();
    }
}
