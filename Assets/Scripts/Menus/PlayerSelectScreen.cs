using UnityEngine;
using System.Collections;

public class PlayerSelectScreen : MonoBehaviour {
	public int playerCount;
	// Use this for initialization
	void Start () {
		PlayerManager.playerCount = playerCount;
		for(int i = playerCount;i<PlayerManager.podSkins.Length;i++){
			PlayerManager.podSkins[i] = Random.Range(0,4);
		}
	}
}
