using UnityEngine;
public static class ControllerInput {
	private static Controller[] controllers;


	static ControllerInput(){
		controllers = new Controller[4];
		for(uint i = 0; i<4; i++){
#if UNITY_STANDALONE_WIN
			controllers[i]=new PCController(i);
#else
			controllers[i]=new MacController(i);
#endif
		}

		pollInput();
	}

	public static void pollInput(){
		foreach(Controller c in controllers)c.pollInput();
	}


}
