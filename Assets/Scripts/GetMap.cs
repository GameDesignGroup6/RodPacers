using UnityEngine;
using System.Collections;

public class GetMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(PlayerManager.playerCount==0)
			Application.LoadLevelAdditive ("Test1");
	}
}
