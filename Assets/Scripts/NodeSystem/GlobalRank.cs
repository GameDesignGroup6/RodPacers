using UnityEngine;
using System.Collections;

public class GlobalRank : MonoBehaviour {
	private NodeRank[] players;
	private NodeRank[] rankings;
	// Use this for initialization
	void Start () {
		players = FindObjectsOfType<NodeRank>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		rankings = players.Clone() as NodeRank[];
		System.Array.Sort(rankings);
		for(int i=0; i<rankings.Length;i++){
//			players[rankings[i].playerNumber-1].rank = i+1;
			rankings[i].rank = i+1;
			DebugHUD.setValue("Player "+players[i].playerNumber+" rank",players[i].rank);
			rankings[i].updateText();
		}
	}
}
