using UnityEngine;
using System.Collections;

public class PodScript : MonoBehaviour {
	public Node currentNode;
	public Node goalNode;
	public int nodesPassed;
	// Use this for initialization
	void Start () {
	
	}

	public void passedANode(){
		nodesPassed++;
	}
	public int getNodesPassed(){
		return nodesPassed;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
