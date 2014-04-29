using UnityEngine;
using System.Collections;

public class LeaderBoardHUD : MonoBehaviour {
	string[,] leaderBoard;
	// Use this for initialization
	void Start () {
		leaderBoard = GameObject.Find ("Rank").GetComponent<Rank> ().leaderBoard;
		if (leaderBoard == null)
			Debug.Log ("can't find rank object");
		transform.Find("4").Find("p4").GetComponent<GUIText>().text=leaderBoard[0,0];
		transform.Find("3").Find("p3").GetComponent<GUIText>().text=leaderBoard[1,0];
		transform.Find("2").Find("p2").GetComponent<GUIText>().text=leaderBoard[2,0];
		transform.Find("1").Find("p1").GetComponent<GUIText>().text=leaderBoard[3,0];
		transform.Find("4").Find("time4").GetComponent<GUIText>().text=leaderBoard[0,1];
		transform.Find("3").Find("time3").GetComponent<GUIText>().text=leaderBoard[1,1];
		transform.Find("2").Find("time2").GetComponent<GUIText>().text=leaderBoard[2,1];
		transform.Find("1").Find("time1").GetComponent<GUIText>().text=leaderBoard[3,1];
		Destroy (GameObject.Find ("Rank"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
