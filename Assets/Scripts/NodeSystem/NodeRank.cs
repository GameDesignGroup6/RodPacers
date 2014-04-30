using UnityEngine;
using System.Collections;
[RequireComponent(typeof(NodeRespawn))]
public class NodeRank : MonoBehaviour, System.IComparable<NodeRank> {
	private NodeRespawn spawn;
	public float distanceFromStart;
	public int playerNumber;
	public int lap;
	public int rank;
	public GUIText text;
	// Use this for initialization
	void Start () {
		spawn = GetComponent<NodeRespawn>();
	}
	
	// Update is called once per frame
	void Update () {
		distanceFromStart = spawn.currentNode.DistanceFromStart-Vector3.Distance(transform.position,spawn.nodeTransform.position);
		DebugHUD.setValue(transform.parent.name+"/"+name+" distance",distanceFromStart);
	}
	public void updateText(){
		if(text!=null)text.text = rank+"";
	}
	public int CompareTo(NodeRank orank){
		if(lap>orank.lap){
			return -1;
		}else if(lap<orank.lap){
			return 1;
		}
		if(distanceFromStart>orank.distanceFromStart){
			return -1;
		}else if(distanceFromStart<orank.distanceFromStart){
			return 1;
		}
		if(playerNumber<orank.playerNumber){
			return -1;
		}else if(playerNumber>orank.playerNumber){
			return 1;
		}
		return 0;
	}
}
