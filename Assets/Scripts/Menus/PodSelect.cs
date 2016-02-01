using UnityEngine;
using System.Collections;
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
using XInputDotNetPure;
#endif


[RequireComponent(typeof(PodSkin),typeof(bouncySpinnyCubeScript))]
public class PodSelect : MonoBehaviour {
	public GUIText podDescription;
	private PodSkin skinToChange;
	private int selectedPod;
	public int playerNumber;
	public int maxPodNumber = 2;
	public int minPodNumber = 1;
	private float updateIsTooFast = 0.25f;
	private bouncySpinnyCubeScript bscs;


	// Use this for initialization
	void Start () {
		selectedPod = 1;
		skinToChange = GetComponent<PodSkin>();
		skinToChange.ChangeSkin(selectedPod);
		PlayerManager.podSkins[playerNumber-1] = selectedPod;
		bscs = GetComponent<bouncySpinnyCubeScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerNumber < 1 || playerNumber > 4) return;
        //begin RPAAEE changes
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        float leftStickHoriz = GamePad.GetState((PlayerIndex)(playerNumber - 1)).ThumbSticks.Left.X;
        float rightStickHoriz = GamePad.GetState((PlayerIndex)(playerNumber - 1)).ThumbSticks.Right.X;
#else
        float leftStickHoriz = Input.GetAxis("LeftStickHoriz"+playerNumber);
        float rightStickHoriz = Input.GetAxis("RightStickHoriz"+playerNumber);
#endif

        
        bscs.spinRate.y = 16 + 72 * rightStickHoriz;

		if (updateIsTooFast > 0) {
			updateIsTooFast-=Time.deltaTime;
			return;
		}



        if (leftStickHoriz<-0.7f){
			selectedPod--;
			if(selectedPod<minPodNumber&&!(Input.GetKey("joystick "+playerNumber+" button 6")&&selectedPod>=0))selectedPod = maxPodNumber;
			skinToChange.ChangeSkin(selectedPod);
			updateIsTooFast = 0.25f;
			PlayerManager.podSkins[playerNumber-1] = selectedPod;
		}
		if(leftStickHoriz>0.7f){
			selectedPod++;
			if(selectedPod>maxPodNumber && !(Input.GetKey("joystick "+playerNumber+" button 6")&&selectedPod<SkinManager.SkinList.Length))selectedPod = minPodNumber;
			skinToChange.ChangeSkin(selectedPod);
			updateIsTooFast = 0.25f;
			PlayerManager.podSkins[playerNumber-1] = selectedPod;
		}

        //end RPAEE changes

		switch(selectedPod) {
		case 0: podDescription.text = "Default";
			break;
		case 1: podDescription.text = "Custom Radon-Ulzer 620C";
			break;
		case 2: podDescription.text = "Plug-F Mammoth Split X";
			break;
		case 3: podDescription.text = "KV9T9-B Wasp";
			break;
		case 4: podDescription.text = "GPE-3130";
			break;
		case 5: podDescription.text = "Twin Telephone Booths";
			break;
		default: podDescription.text = "Pod";
			break;
		}
	}
}
