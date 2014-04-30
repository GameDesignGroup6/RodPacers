using UnityEngine;
using System.Collections;

public class LeaderBoard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NodeRank[] players = GlobalRank.finalRanks;
		for(int i = 0; i<players.Length;i++){
			GUIText name = transform.Find((i+1)+"/name").guiText;
			GUIText time = transform.Find((i+1)+"/time").guiText;
			NodeRank rank = players[i];
//			bool ai = !rank.playerNumber<=PlayerManager.playerCount;
			time.text = timeToString(rank.finishTime);
			name.text = getPlayerName(rank.playerNumber);
		}
	}
	private string getPlayerName(int player){
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
