#if UNITY_STANDALONE_OSX
using UnityEngine;

public class MacController : Controller {
	private int pn;//player number (for axis names)
	public MacController(uint number):base(number){
		pn = number+1;
		pollInput();
	}
	public override void pollInput (){}

	public override float getAnalog (AnalogControls control)
	{
		switch(control){
		case AnalogControls.LEFT_STICK_X: return Input.GetAxis("LeftStickHoriz"+pn);
		case AnalogControls.LEFT_STICK_Y: return pn==1?Input.GetAxis("LeftStickVert"):0f;
		case AnalogControls.RIGHT_STICK_X: return Input.GetAxis("RightStickHoriz"+pn);
		case AnalogControls.RIGHT_STICK_Y: return pn==1?Input.GetAxis("RightStickVert"):0f;
		case AnalogControls.LEFT_TRIGGER: return Input.GetAxis("LeftTrigger"+pn);
		case AnalogControls.RIGHT_TRIGGER: return Input.GetAxis("RightTrigger"+pn);
		}
		return 0f;
	}
	public override float getAnalogDelta (AnalogControls control)
	{
		return 0f;
	}
	public override bool getDigital (DigitalControls button)
	{
		switch(button){
		case DigitalControls.BUTTON_A: return Input.GetKey("joystick "+pn+" button 16");
		case DigitalControls.BUTTON_B: return Input.GetKey("joystick "+pn+" button 17");
		case DigitalControls.BUTTON_X: return Input.GetKey("joystick "+pn+" button 18");
		case DigitalControls.BUTTON_Y: return Input.GetKey("joystick "+pn+" button 19");
		case DigitalControls.BUTTON_BACK: return Input.GetKey("joystick "+pn+" button 10");
		case DigitalControls.BUTTON_START: return Input.GetKey("joystick "+pn+" button 9");
		case DigitalControls.BUTTON_GUIDE: return Input.GetKey("joystick "+pn+" button 15");
		case DigitalControls.BUTTON_LB: return Input.GetKey("joystick "+pn+" button 13");
		case DigitalControls.BUTTON_RB: return Input.GetKey("joystick "+pn+" button 14");
		case DigitalControls.BUTTON_LS: return Input.GetKey("joystick "+pn+" button 11");
		case DigitalControls.BUTTON_RS: return Input.GetKey("joystick "+pn+" button 12");
		case DigitalControls.DPAD_N: return Input.GetKey("joystick "+pn+" button 5");
		case DigitalControls.DPAD_S: return Input.GetKey("joystick "+pn+" button 6");
		case DigitalControls.DPAD_E: return Input.GetKey("joystick "+pn+" button 8");
		case DigitalControls.DPAD_W: return Input.GetKey("joystick "+pn+" button 7");
		}
		return false;
	}
	public override bool getDigitalDown (DigitalControls button)
	{
		switch(button){
		case DigitalControls.BUTTON_A: return Input.GetKeyDown("joystick "+pn+" button 16");
		case DigitalControls.BUTTON_B: return Input.GetKeyDown("joystick "+pn+" button 17");
		case DigitalControls.BUTTON_X: return Input.GetKeyDown("joystick "+pn+" button 18");
		case DigitalControls.BUTTON_Y: return Input.GetKeyDown("joystick "+pn+" button 19");
		case DigitalControls.BUTTON_BACK: return Input.GetKeyDown("joystick "+pn+" button 10");
		case DigitalControls.BUTTON_START: return Input.GetKeyDown("joystick "+pn+" button 9");
		case DigitalControls.BUTTON_GUIDE: return Input.GetKeyDown("joystick "+pn+" button 15");
		case DigitalControls.BUTTON_LB: return Input.GetKeyDown("joystick "+pn+" button 13");
		case DigitalControls.BUTTON_RB: return Input.GetKeyDown("joystick "+pn+" button 14");
		case DigitalControls.BUTTON_LS: return Input.GetKeyDown("joystick "+pn+" button 11");
		case DigitalControls.BUTTON_RS: return Input.GetKeyDown("joystick "+pn+" button 12");
		case DigitalControls.DPAD_N: return Input.GetKeyDown("joystick "+pn+" button 5");
		case DigitalControls.DPAD_S: return Input.GetKeyDown("joystick "+pn+" button 6");
		case DigitalControls.DPAD_E: return Input.GetKeyDown("joystick "+pn+" button 8");
		case DigitalControls.DPAD_W: return Input.GetKeyDown("joystick "+pn+" button 7");
		}
		return false;
	}
	public override bool getAnalogAsDigital (AnalogAsDigitalControls control)
	{
		switch(control){
		case AnalogAsDigitalControls.LEFT_STICK_UP: return getAnalog(control)>=ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.LEFT_STICK_DOWN: return getAnalog(control)<=-ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.LEFT_STICK_LEFT: return getAnalog(control)<=-ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.LEFT_STICK_RIGHT: return getAnalog(control)>=ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.RIGHT_STICK_UP: return getAnalog(control)>=ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.RIGHT_STICK_DOWN: return getAnalog(control)<=-ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.RIGHT_STICK_LEFT: return getAnalog(control)<=-ANALOG_AS_DIGITAL_THRESHOLD;
		case AnalogAsDigitalControls.RIGHT_STICK_RIGHT: return getAnalog(control)>=ANALOG_AS_DIGITAL_THRESHOLD;
		}
		return false;
	}
	public override bool getAnalogAsDigitalDown (AnalogAsDigitalControls control)
	{
		throw new System.NotImplementedException ();
	}
	public override bool isConnected ()
	{
		return true;
	}
}
#endif