using UnityEngine;
using System.Collections;

using XInputDotNetPure;

public class XinputTest : MonoBehaviour {

    public PlayerIndex player;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        var state = GamePad.GetState(player);
        DebugHUD.setValue("PlayerIndex", player.ToString());
        DebugHUD.setValue("isConnected", state.IsConnected);
        DebugHUD.setValue("ThumbSticks.Left.X", state.ThumbSticks.Left.X);
        DebugHUD.setValue("ThumbSticks.Left.Y", state.ThumbSticks.Left.Y);
        DebugHUD.setValue("ThumbSticks.Right.X", state.ThumbSticks.Right.X);
        DebugHUD.setValue("ThumbSticks.Right.Y", state.ThumbSticks.Right.Y);
        DebugHUD.setValue("Triggers.Left", state.Triggers.Left);
        DebugHUD.setValue("Triggers.Right", state.Triggers.Right);
        DebugHUD.setValue("Buttons.A", state.Buttons.A.ToString());
        DebugHUD.setValue("Buttons.B", state.Buttons.B.ToString());
        DebugHUD.setValue("Buttons.X", state.Buttons.X.ToString());
        DebugHUD.setValue("Buttons.Y", state.Buttons.Y.ToString());
        DebugHUD.setValue("Buttons.Start", state.Buttons.Start.ToString());
        DebugHUD.setValue("Buttons.Back", state.Buttons.Back.ToString());
        DebugHUD.setValue("Buttons.Guide", state.Buttons.Guide.ToString());
        DebugHUD.setValue("Buttons.LeftShoulder", state.Buttons.LeftShoulder.ToString());
        DebugHUD.setValue("Buttons.RightShoulder", state.Buttons.RightShoulder.ToString());
        DebugHUD.setValue("Buttons.LeftStick", state.Buttons.LeftStick.ToString());
        DebugHUD.setValue("Buttons.RightStick", state.Buttons.RightStick.ToString());
        DebugHUD.setValue("DPad.Up", state.DPad.Up.ToString());
        DebugHUD.setValue("DPad.Down", state.DPad.Down.ToString());
        DebugHUD.setValue("DPad.Left", state.DPad.Left.ToString());
        DebugHUD.setValue("DPad.Right", state.DPad.Right.ToString());
    }
}
