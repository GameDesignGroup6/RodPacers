using UnityEngine;
using System.Collections;

public class StartCountDown : MonoBehaviour {

	public int count;
	public float deltaTime;
	public float timePassed;

	// Use this for initialization
	void Start () {
		count = 4;//we're counting down from 3, right?
		gameObject.guiText.fontSize= 200;
		gameObject.guiText.text="<color=red>"+count + "</color>";
		deltaTime = Time.realtimeSinceStartup;
		Time.timeScale=0;//freeze pods
	}
	
	// Update is called once per frame
	void Update () {
		timePassed +=Time.realtimeSinceStartup - deltaTime;
		deltaTime = Time.realtimeSinceStartup;
		PauseCount();
	}

	//an implementation of count that can be run during a pause
	void PauseCount(){
		if (timePassed > 1f){
			count--;
			timePassed=0;
		}
		if (count==0){
			gameObject.guiText.text="<color=red>"+ "Go!" + "</color>";
			Input.ResetInputAxes();
		}
		else if(count<0){
			DoneCounting();
		}
		else
			gameObject.guiText.text="<color=red>"+count + "</color>";
	}

	void DoneCounting(){
		Time.timeScale=1;//unfreeze pods
		Destroy(gameObject); //destroys the guitext
	}
}
