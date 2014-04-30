﻿using UnityEngine;
using System.Collections;

public class GlobalRank : MonoBehaviour {
	public int lapsToWin = 1;
	private NodeRank[] players;
	private NodeRank[] rankings;
	public static NodeRank[] finalRanks;
	// Use this for initialization
	void Start () {
		players = FindObjectsOfType<NodeRank>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		int playersFinished = 0;
		for(int i = 0; i<PlayerManager.playerCount;i++){
			if(players[i].lap>=lapsToWin){
				if(players[i].finishTime<0f){
					players[i].finishTime = Time.timeSinceLevelLoad;
					players[i].finished = true;
				}
				playersFinished++;
			}
		}
		if(playersFinished==PlayerManager.playerCount){
			System.Array.Sort(players);
			finalRanks = players;
			Application.LoadLevel("FinishScene");
			return;
		}
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
