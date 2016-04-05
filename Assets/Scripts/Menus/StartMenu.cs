using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

    // The options to choose from
    public GUIText[] menuChoices;

    // Where each option leads
    public string[] nextScenes;

    // The current position in the menu
    private int position = 0;

    // Make it so it only changes every quarter second if you hold down the button
    private float updateIsTooFast = .25f;

    void Start() {
        //Cursor.visible = false;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //menuChoices[0].color = Color.white;
    }

    // Update is called once per frame
    void Update() {
        //begin IOS changes
//        if (Input.touchCount == 1) {
//            var touch = Input.touches[0];
//            if (touch.phase == TouchPhase.Ended) {
//                for (int x = 0; x < menuChoices.Length; x++) {
//                    if (menuChoices[x].HitTest(touch.position)) {
//                        if (nextScenes[x] == "Quit") {
//                            Application.Quit();
//                        } else {
//                            Application.LoadLevel(nextScenes[x]);
//                        }
//                    }
//                }
//            }
//        }
		if (Input.GetMouseButtonDown(0)) {
			for (int x = 0; x < menuChoices.Length; x++) {
				if (menuChoices[x].HitTest(Input.mousePosition)) {
					menuChoices[x].color = Color.white;
					if (nextScenes[x] == "Quit") {
						Application.Quit();
					} else {
						Application.LoadLevel(nextScenes[x]);
					}
				}
			}
		}
        //end IOS changes

        if (updateIsTooFast > 0) {
            updateIsTooFast = updateIsTooFast - Time.deltaTime;
            return;
        }

        if (Input.GetAxis("LeftStickVert1") > 0.1f) {
            menuChoices[position].color = Color.yellow;
            position--;
            if (position < 0) {
                position = menuChoices.Length - 1;
            }
            updateIsTooFast = 0.25f;
        }
        if (Input.GetAxis("LeftStickVert1") < -0.1f) {
            menuChoices[position].color = Color.yellow;
            position = (position + 1) % menuChoices.Length;
            updateIsTooFast = 0.25f;
        }

//        menuChoices[position].color = Color.white; // TURNED OFF FOR IOS

        if (Input.GetAxis("Throttle1") > 0) {
            if (nextScenes[position] == "Quit") {
                Application.Quit();
            } else {
                Application.LoadLevel(nextScenes[position]);
            }
        }

        // B makes it go back but not quit
        if (Input.GetAxis("Throttle1") < 0) {
            if (nextScenes[nextScenes.Length - 1] != "Quit") {
                Application.LoadLevel(nextScenes[nextScenes.Length - 1]);
            }
        }


    }

}
