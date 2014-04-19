using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PodSkin))]
public class PodSelect : MonoBehaviour {
	private PodSkin skinToChange;
	private int selectedPod;
	public int playerNumber;
	public int maxPodNumber = 2;
	public int minPodNumber = 1;
	private float updateIsTooFast = 0.25f;


	// Use this for initialization
	void Start () {
		selectedPod = 1;
		skinToChange = GetComponent<PodSkin>();
		skinToChange.ChangeSkin(selectedPod);
	}
	
	// Update is called once per frame
	void Update () {
		if(playerNumber<1||playerNumber>4)return;
		if (updateIsTooFast > 0) {
			updateIsTooFast-=Time.deltaTime;
			return;
		}
		if(Input.GetAxis("LeftStickHoriz"+playerNumber)<-0.025f){
			selectedPod--;
			if(selectedPod<minPodNumber)selectedPod = maxPodNumber;
			skinToChange.ChangeSkin(selectedPod);
			updateIsTooFast = 0.25f;
			PlayerManager.podSkins[playerNumber] = selectedPod;
		}
		if(Input.GetAxis("LeftStickHoriz"+playerNumber)>0.025f){
			selectedPod++;
			if(selectedPod>maxPodNumber)selectedPod = minPodNumber;
			skinToChange.ChangeSkin(selectedPod);
			updateIsTooFast = 0.25f;
			PlayerManager.podSkins[playerNumber] = selectedPod;
		}
	}
}
