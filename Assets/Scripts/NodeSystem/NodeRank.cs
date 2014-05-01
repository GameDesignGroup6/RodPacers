using UnityEngine;
using System.Collections;
[RequireComponent(typeof(NodeRespawn))]
public class NodeRank : MonoBehaviour, System.IComparable<NodeRank> {
	public int playerNumber;
	public int lap;
	public int rank;
	public GUIText text;
	public Checkpoint curCheckpoint;
	public float distanceToNextCheckpoint;
	private SpawnManager manager;
	public float finishTime = -1f;
	public bool finished = false;
	// Use this for initialization
	void Start () {
		manager = transform.parent.GetComponent<SpawnManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(finished)return;
		if(manager.lapFinished){
			Debug.Log ("Finished a lap!");
			lap++;
			manager.lapFinished = false;
		}
		curCheckpoint = manager.lastCheckpoint;
		if(curCheckpoint==null)return;
//		distanceToNextCheckpoint = curCheckpoint.next.collider.ClosestPointOnBounds(transform.position).magnitude;
		distanceToNextCheckpoint = Vector3.Distance(transform.position,curCheckpoint.next.transform.position);

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
		if(manager.gateCount>orank.manager.gateCount){
			return -1;
		}else if(manager.gateCount<orank.manager.gateCount){
			return 1;
		}
		if(distanceToNextCheckpoint<orank.distanceToNextCheckpoint){
			return -1;
		}else if(distanceToNextCheckpoint>orank.distanceToNextCheckpoint){
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
