using UnityEngine;
using System.Collections;

public class LeaderBoard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NodeRank[] players = GlobalRank.finalRanks;
		NodeRank[] sortedPlayers = new NodeRank[players.Length];
		for(int i = 0;i<players.Length;i++){
			for(int p = 0; p<players.Length;p++){
				if(players[p].rank==i+1){
					sortedPlayers[i] = players[p];
					break;
				}
			}
		}


		for(int i = 0; i<sortedPlayers.Length;i++){
			GUIText name = transform.Find((i+1)+"/name").GetComponent<GUIText>();
			GUIText time = transform.Find((i+1)+"/time").GetComponent<GUIText>();
			NodeRank rank = sortedPlayers[i];
//			bool ai = !rank.playerNumber<=PlayerManager.playerCount;
			time.text = timeToString(rank.finishTime);
			name.text = getPlayerName(rank.playerNumber);
		}
	}
	public static string getPlayerName(int player){
		switch(player){
		case 1: return "<color=red>Player 1</color>";
		case 2: return "<color=blue>Player 2</color>";
		case 3: return "<color=green>Player 3</color>";
		case 4: return "<color=yellow>Player 4</color>";
		default: return "<color=magenta>Robot Kyle</color>";
		}
	}
	private string timeToString(float time){
		if(time<0f)return "<color=red>DNF</color>";
		return "<color=yellow>" + (int)(time/60) + ":" + (int)((time%60)/10)
			+ (int)((time%60)%10) + ":" + (int)(time%1 * 10) + (int)(time%.1 * 100)
				+ (int)(time%.01 * 1000) + "</color>" ;
	}
}
