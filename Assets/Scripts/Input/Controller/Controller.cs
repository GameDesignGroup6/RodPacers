public abstract class Controller {
	protected const float ANALOG_AS_DIGITAL_THRESHOLD = 0.5f;
	protected uint number;
	public enum AnalogControls{
		LEFT_STICK_X,
		LEFT_STICK_Y,
		RIGHT_STICK_X,
		RIGHT_STICK_Y,
		LEFT_TRIGGER,
		RIGHT_TRIGGER
	}
	public enum DigitalControls{
		BUTTON_A,
		BUTTON_B,
		BUTTON_X,
		BUTTON_Y,
		BUTTON_START,
		BUTTON_BACK,
		BUTTON_LB,
		BUTTON_RB,
		DPAD_N,
		DPAD_E,
		DPAD_S,
		DPAD_W,
		BUTTON_LS,
		BUTTON_RS,
		BUTTON_GUIDE
	}
	public enum AnalogAsDigitalControls{
		LEFT_STICK_UP,
		LEFT_STICK_DOWN,
		LEFT_STICK_LEFT,
		LEFT_STICK_RIGHT,
		RIGHT_STICK_UP,
		RIGHT_STICK_DOWN,
		RIGHT_STICK_LEFT,
		RIGHT_STICK_RIGHT
	}
	public abstract void pollInput();
	public abstract float getAnalog(AnalogControls control);//current value
	public abstract float getAnalogDelta(AnalogControls control);//change since last frame
	public abstract bool getDigitalDown(DigitalControls button);//pressed this frame
	public abstract bool getDigital(DigitalControls button);//is it currently down?
	public abstract bool getAnalogAsDigitalDown(AnalogAsDigitalControls control);
	public abstract bool getAnalogAsDigital(AnalogAsDigitalControls control);
#if UNITY_STANDALONE_WIN
	public abstract void setVibration(float left, float right);//left is coarse, right is fine; PC ONLY
#endif
	public abstract bool isConnected();

	public Controller(uint number){
		this.number = number;
	}


}
