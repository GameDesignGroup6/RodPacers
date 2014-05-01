using UnityEngine;
using System.Collections;

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
		if(playerNumber<1||playerNumber>4)return;
		bscs.spinRate.y = 16+72*Input.GetAxis("RightStickHoriz"+playerNumber);


		if (updateIsTooFast > 0) {
			updateIsTooFast-=Time.deltaTime;
			return;
		}
		if(Input.GetAxis("LeftStickHoriz"+playerNumber)<-0.7f){
			selectedPod--;
			if(selectedPod<minPodNumber&&!(Input.GetKey("joystick "+playerNumber+" button 6")&&selectedPod>=0))selectedPod = maxPodNumber;
			skinToChange.ChangeSkin(selectedPod);
			updateIsTooFast = 0.25f;
			PlayerManager.podSkins[playerNumber-1] = selectedPod;
		}
		if(Input.GetAxis("LeftStickHoriz"+playerNumber)>0.7f){
			selectedPod++;
			if(selectedPod>maxPodNumber && !(Input.GetKey("joystick "+playerNumber+" button 6")&&selectedPod<SkinManager.SkinList.Length))selectedPod = minPodNumber;
			skinToChange.ChangeSkin(selectedPod);
			updateIsTooFast = 0.25f;
			PlayerManager.podSkins[playerNumber-1] = selectedPod;
		}

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
