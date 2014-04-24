using UnityEngine;
using System.Collections;

public class GetMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//if(PlayerManager.playerCount==0)
		switch(PlayerManager.playerCount){
		case 1: Application.LoadLevelAdditive("SinglePlayer");break;
		case 2: Application.LoadLevelAdditive("TwoPlayer");break;
		case 3: Application.LoadLevelAdditive("ThreePlayer");break;
		case 4: Application.LoadLevelAdditive("FourPlayer");break;
		default:Debug.LogError("Impossible number of players!");break;
		}
	}
}
