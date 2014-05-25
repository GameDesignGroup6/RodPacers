#if UNITY_STANDALONE_WIN
using XInputDotNetPure;

public class PCController : Controller {

	private GamePadState lastState;
	private GamePadState curState;

	public PCController(uint number) : base(number){
		curState = GamePad.GetState((PlayerIndex)number);
	}

	public override void pollInput (){
		lastState = curState;
		curState = GamePad.GetState((PlayerIndex)number);
	}

	public override float getAnalog (AnalogControls control)
	{
		switch(control){
		case AnalogControls.LEFT_STICK_X: return curState.ThumbSticks.Left.X;
		case AnalogControls.LEFT_STICK_Y: return curState.ThumbSticks.Left.Y;
		case AnalogControls.RIGHT_STICK_X: return curState.ThumbSticks.Right.X;
		case AnalogControls.RIGHT_STICK_Y: return curState.ThumbSticks.Right.Y;
		case AnalogControls.LEFT_TRIGGER: return curState.Triggers.Left;
		case AnalogControls.RIGHT_TRIGGER: return curState.Triggers.Right;
		}
		return 0f;
	}
	public override float getAnalogDelta (AnalogControls control)
	{
		switch(control){
		case AnalogControls.LEFT_STICK_X: return curState.ThumbSticks.Left.X-lastState.ThumbSticks.Left.X;
		case AnalogControls.LEFT_STICK_Y: return curState.ThumbSticks.Left.Y-lastState.ThumbSticks.Left.Y;
		case AnalogControls.RIGHT_STICK_X: return curState.ThumbSticks.Right.X-lastState.ThumbSticks.Right.X;
		case AnalogControls.RIGHT_STICK_Y: return curState.ThumbSticks.Right.Y-lastState.ThumbSticks.Right.Y;
		case AnalogControls.LEFT_TRIGGER: return curState.Triggers.Left-lastState.Triggers.Left;
		case AnalogControls.RIGHT_TRIGGER: return curState.Triggers.Right-lastState.Triggers.Right;
		}
		return 0f;
	}
	public override bool getDigital (DigitalControls button)
	{
		switch(button){
		case DigitalControls.BUTTON_A: return curState.Buttons.A==ButtonState.Pressed;
		case DigitalControls.BUTTON_B: return curState.Buttons.B==ButtonState.Pressed;
		case DigitalControls.BUTTON_X: return curState.Buttons.X==ButtonState.Pressed;
		case DigitalControls.BUTTON_Y: return curState.Buttons.Y==ButtonState.Pressed;
		case DigitalControls.BUTTON_BACK: return curState.Buttons.Back==ButtonState.Pressed;
		case DigitalControls.BUTTON_START: return curState.Buttons.Start==ButtonState.Pressed;
		case DigitalControls.BUTTON_GUIDE: return curState.Buttons.Guide==ButtonState.Pressed;
		case DigitalControls.BUTTON_LB: return curState.Buttons.LeftShoulder==ButtonState.Pressed;
		case DigitalControls.BUTTON_RB: return curState.Buttons.RightShoulder==ButtonState.Pressed;
		case DigitalControls.BUTTON_LS: return curState.Buttons.LeftStick==ButtonState.Pressed;
		case DigitalControls.BUTTON_RS: return curState.Buttons.RightStick==ButtonState.Pressed;
		case DigitalControls.DPAD_N: return curState.DPad.Up==ButtonState.Pressed;
		case DigitalControls.DPAD_S: return curState.DPad.Down==ButtonState.Pressed;
		case DigitalControls.DPAD_E: return curState.DPad.Right==ButtonState.Pressed;
		case DigitalControls.DPAD_W: return curState.DPad.Left==ButtonState.Pressed;
		}
		return false;
	}
	public override bool getDigitalDown (DigitalControls button)
	{
		switch(button){
		case DigitalControls.BUTTON_A: return curState.Buttons.A==ButtonState.Pressed && lastState.Buttons.A==ButtonState.Released;
		case DigitalControls.BUTTON_B: return curState.Buttons.B==ButtonState.Pressed && lastState.Buttons.B==ButtonState.Released;
		case DigitalControls.BUTTON_X: return curState.Buttons.X==ButtonState.Pressed && lastState.Buttons.X==ButtonState.Released;
		case DigitalControls.BUTTON_Y: return curState.Buttons.Y==ButtonState.Pressed && lastState.Buttons.Y==ButtonState.Released;
		case DigitalControls.BUTTON_BACK: return curState.Buttons.Back==ButtonState.Pressed && lastState.Buttons.Back==ButtonState.Released;
		case DigitalControls.BUTTON_START: return curState.Buttons.Start==ButtonState.Pressed && lastState.Buttons.Start==ButtonState.Released;
		case DigitalControls.BUTTON_GUIDE: return curState.Buttons.Guide==ButtonState.Pressed && lastState.Buttons.Guide==ButtonState.Released;
		case DigitalControls.BUTTON_LB: return curState.Buttons.LeftShoulder==ButtonState.Pressed && lastState.Buttons.LeftShoulder==ButtonState.Released;
		case DigitalControls.BUTTON_RB: return curState.Buttons.RightShoulder==ButtonState.Pressed && lastState.Buttons.RightShoulder==ButtonState.Released;
		case DigitalControls.BUTTON_LS: return curState.Buttons.LeftStick==ButtonState.Pressed && lastState.Buttons.LeftStick==ButtonState.Released;
		case DigitalControls.BUTTON_RS: return curState.Buttons.RightStick==ButtonState.Pressed && lastState.Buttons.RightStick==ButtonState.Released;
		case DigitalControls.DPAD_N: return curState.DPad.Up==ButtonState.Pressed && lastState.DPad.Up==ButtonState.Released;
		case DigitalControls.DPAD_S: return curState.DPad.Down==ButtonState.Pressed && lastState.DPad.Down==ButtonState.Released;
		case DigitalControls.DPAD_E: return curState.DPad.Right==ButtonState.Pressed && lastState.DPad.Right==ButtonState.Released;
		case DigitalControls.DPAD_W: return curState.DPad.Left==ButtonState.Pressed && lastState.DPad.Left==ButtonState.Released;
		}
		return false;
	}
	public override bool isConnected ()
	{
		return curState.IsConnected;
	}
	public override void setVibration (float left, float right)
	{
		GamePad.SetVibration((PlayerIndex)number,left,right);
	}
	public override bool getAnalogAsDigital (AnalogAsDigitalControls control)
	{
		switch(control){
		case AnalogAsDigitalControls.LEFT_STICK_UP: return curState.ThumbSticks.Left.Y>=ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.LEFT_STICK_DOWN: return curState.ThumbSticks.Left.Y<=-ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.LEFT_STICK_LEFT: return curState.ThumbSticks.Left.X<=-ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.LEFT_STICK_RIGHT: return curState.ThumbSticks.Left.X>=ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.RIGHT_STICK_UP: return curState.ThumbSticks.Right.Y>=ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.RIGHT_STICK_DOWN: return curState.ThumbSticks.Right.Y<=-ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.RIGHT_STICK_LEFT: return curState.ThumbSticks.Right.X<=-ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.RIGHT_STICK_RIGHT: return curState.ThumbSticks.Right.X>=ANALOG_AS_DIGITAL_THRESHOLD;
		}
		return false;
	}
	public override bool getAnalogAsDigitalDown (AnalogAsDigitalControls control)
	{
		switch(control){
		case AnalogAsDigitalControls.LEFT_STICK_UP: return curState.ThumbSticks.Left.Y>=ANALOG_AS_DIGITAL_THRESHOLD && lastState.ThumbSticks.Left.Y<ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.LEFT_STICK_DOWN: return curState.ThumbSticks.Left.Y<=-ANALOG_AS_DIGITAL_THRESHOLD && lastState.ThumbSticks.Left.Y>-ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.LEFT_STICK_LEFT: return curState.ThumbSticks.Left.X<=-ANALOG_AS_DIGITAL_THRESHOLD && lastState.ThumbSticks.Left.X>-ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.LEFT_STICK_RIGHT: return curState.ThumbSticks.Left.X>=ANALOG_AS_DIGITAL_THRESHOLD && lastState.ThumbSticks.Left.X<ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.RIGHT_STICK_UP: return curState.ThumbSticks.Right.Y>=ANALOG_AS_DIGITAL_THRESHOLD && lastState.ThumbSticks.Right.Y<ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.RIGHT_STICK_DOWN: return curState.ThumbSticks.Right.Y<=-ANALOG_AS_DIGITAL_THRESHOLD && lastState.ThumbSticks.Right.Y>-ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.RIGHT_STICK_LEFT: return curState.ThumbSticks.Right.X<=-ANALOG_AS_DIGITAL_THRESHOLD && lastState.ThumbSticks.Right.X>-ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.RIGHT_STICK_RIGHT: return curState.ThumbSticks.Right.X>=ANALOG_AS_DIGITAL_THRESHOLD && lastState.ThumbSticks.Right.X<ANALOG_AS_DIGITAL_THRESHOLD;
		}
		return false;
	}
}
#endif
