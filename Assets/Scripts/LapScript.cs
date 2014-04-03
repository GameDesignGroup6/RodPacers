using UnityEngine;
using System.Collections;

public class LapScript : MonoBehaviour {

<<<<<<< HEAD
	public AudioSource podSound, trackMusic, endingMusic;
=======
>>>>>>> 8b964c1d497f2913bd9a7091756604a5ee21b852
	private int inOrder = 0;
	private bool rightWay = false;
	private bool backwards = false;

	void Start() {
<<<<<<< HEAD
		endingMusic.playOnAwake = false;
=======
>>>>>>> 8b964c1d497f2913bd9a7091756604a5ee21b852
		backwards = false;
		rightWay = true;
		inOrder = 0;
		DebugHUD.setValue ("backwards", backwards);
		//DebugHUD.setValue ("inOrder", inOrder);
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "First Line" && rightWay == true) {
			if (other.name == "Start1") {
				if (!PlayerManager.Finish ()) {
					PlayerManager.AddLap (inOrder);
				}
				else {
<<<<<<< HEAD
					podSound.Stop ();
					trackMusic.Stop ();
					endingMusic.Play ();
=======
					gameObject.GetComponent<AudioSource>().Stop();
>>>>>>> 8b964c1d497f2913bd9a7091756604a5ee21b852
					//DebugHUD.setValue ("Playing Track Music", 1);
				}
			}
			inOrder++;
			backwards = false;
			rightWay = false;
			//DebugHUD.setValue ("inOrder", inOrder);
			DebugHUD.setValue ("backwards", backwards);
		}
		else if (other.tag == "First Line" && rightWay == false) {
			inOrder--;
			rightWay = true;
			backwards = true;
			//DebugHUD.setValue ("inOrder", inOrder);
			DebugHUD.setValue ("backwards", backwards);
		}
		if (other.tag == "Second Line" && rightWay == false) {
			backwards = false;
			rightWay = true;
			//DebugHUD.setValue ("inOrder", inOrder);
			DebugHUD.setValue ("backwards", backwards);
		}
		else if (other.tag == "Second Line" && rightWay == true) {
			backwards = true;
			rightWay = false;
			//DebugHUD.setValue ("inOrder", inOrder);
			DebugHUD.setValue ("backwards", backwards);
		}
	}
}
