using UnityEngine;
using System.Collections;

// this script shows up each player's rank 
//there should be a showRank GUI text object attach with this script, as a child object of each racer respectively;
[RequireComponent(typeof(GUIText))]
public class ShowRank : MonoBehaviour {
	public Transform currentPlayer;
	PlayerNode playerNode;
	// Use this for initialization
	void Start () {
		playerNode = currentPlayer.GetComponent<PlayerNode> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!playerNode.finished)
			guiText.text = playerNode.position.ToString ();
	}
}
