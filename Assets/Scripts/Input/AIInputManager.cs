using UnityEngine;
using System.Collections;

public class AIInputManager : InputManager {

	float leftOrRight;
	bool backL = false;
	bool backR = false;
	LeftRightTest test;
	ButtonSimulator sim;
	public Transform engineLeft;
	public Transform engineRight;
	ForwardBackSimulator sim2;
	ForwardBackSimulator sim3;

	void Start() {
		test = GetComponent<LeftRightTest>();
		sim = GetComponent<ButtonSimulator>();
		sim2 = engineLeft.GetComponent<ForwardBackSimulator>();
		sim3 = engineRight.GetComponent<ForwardBackSimulator>();
	}

	void Update() {
		leftOrRight = test.dirNum;
		backL = sim2.backwards;
		backR = sim3.backwards;
	}

	public override float getLeftTrigger(){
		if (leftOrRight == -1 && !backL)// || !backR)
			return 1;//sim.currentPress;
		if (leftOrRight == 1 && backL)// || backR)
			return 1;//sim.currentPress;
		else
			return 0;
	}
	public override float getRightTrigger(){
		if (leftOrRight == 1 && !backL)// || !backR)
			return 1;//sim.currentPress;
		if (leftOrRight == -1 && backL)// || backR)
			return 1;//sim.currentPress;
		else
			return 0;
	}
	public override float getThrottle(){
		if (backL)// || backR)
			return -.3f;
		else
			return .8f;
	}
}
