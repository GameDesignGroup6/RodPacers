using UnityEngine;

public class InputPoller : MonoBehaviour {
	private static InputPoller instance;
	private bool canBeDestroyed = false;

	void Awake(){
		DontDestroyOnLoad(this);
	}
	void Start(){
		if(instance==null)instance = this;
	}

	// Update is called once per frame
	void Update () {
		ControllerInput.pollInput();
	}
	void OnDestroy(){
		if(canBeDestroyed)return;
		InputPoller go = Instantiate(instance) as InputPoller;
		go.enabled = true;
		go.gameObject.SetActive(true);
	}
	void OnApplicationQuit(){
		canBeDestroyed = true;
		Destroy(this);
	}
}
