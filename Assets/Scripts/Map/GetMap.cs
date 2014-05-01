using UnityEngine;
using System.Collections;
// well, it really gets the player scene now
public class GetMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Make sure no AI has the same pod as someone else
		int[] forbiddenSkins = new int[PlayerManager.podSkins.Length];
		for(int i = 0; i<PlayerManager.playerCount;i++){
			forbiddenSkins[i] = PlayerManager.podSkins[i];
		}
		int badIndex = PlayerManager.playerCount;
		for(int i = PlayerManager.playerCount; i<PlayerManager.podSkins.Length;i++){

			bool badSkin;
			do{
				PlayerManager.podSkins[i] = Random.Range(1,5);
				badSkin = false;
				for(int i2 = 0; i2<forbiddenSkins.Length; i2++){
					if(PlayerManager.podSkins[i]==forbiddenSkins[i2])badSkin = true;
				}
			}while(badSkin);
			forbiddenSkins[badIndex] = PlayerManager.podSkins[i];
			badIndex++;
		}




		// load the number of players
		switch(PlayerManager.playerCount){
		case 1: Application.LoadLevelAdditive("SinglePlayer");break;
		case 2: Application.LoadLevelAdditive("TwoPlayer");break;
		case 3: Application.LoadLevelAdditive("ThreePlayer");break;
		case 4: Application.LoadLevelAdditive("FourPlayer");break;
		default:Debug.LogError("Impossible number of players!");break;
		}
	}
}
