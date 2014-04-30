using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
	private Engine left,right;
	private Transform lastCheckpointTrans;
	public Checkpoint lastCheckpoint;
	public bool isAI = false;
	[System.NonSerialized]
	public int gateCount = 0;
	[System.NonSerialized]
	public bool lapFinished = false;

	// Use this for initialization
	void Start () {
		Engine[] engines = GetComponentsInChildren<Engine>();
		if(engines.Length!=2){
			Debug.LogError("[SpawnManager][FATAL]Could not locate engines!");
			return;
		}
		if(engines[0].Side==Engine.EngineSide.LEFT){
			left = engines[0];
			right = engines[1];
		}else{
			left = engines[1];
			right = engines[0];
		}

		Checkpoint[] mapPoints = FindObjectsOfType<Checkpoint>();
		foreach(Checkpoint c in mapPoints){
			if(c.number==0){
				lastCheckpoint = c;
				lastCheckpointTrans = c.transform;
				break;
			}
		}


	}
	public void updateCheckpoint(Checkpoint c){
		if(gateCount==lastCheckpoint.number+1&&c.number==0){
			//finished a lap!
			lapFinished = true;
		}
		if(c.number>lastCheckpoint.number){
			gateCount++;
		}else if(c.number<lastCheckpoint.number){
			gateCount--;
		}
		lastCheckpoint = c;
		lastCheckpointTrans = c.transform;
	}
	public void respawnAtLastCheckpoint(){
		if(isAI){
			RespawnAtTransform(GetComponentInChildren<NodeRespawn>().currentNode.previous.transform);
			return;
		}
		if(lastCheckpoint!=null){
			RespawnAtTransform(lastCheckpointTrans);
		}
	}

	public void RespawnAtTransform(Transform trans){
		if(left.EngineHealth.Health<=0){
			left.EngineHealth.SendMessage("Start");
		}
		if(right.EngineHealth.Health<=0){
			right.EngineHealth.SendMessage("Start");
		}

		left.EngineRigidbody.velocity = Vector3.zero;
		right.EngineRigidbody.velocity = Vector3.zero;
		left.EngineRigidbody.angularVelocity = Vector3.zero;
		right.EngineRigidbody.angularVelocity = Vector3.zero;

		left.EngineTransform.rotation = trans.rotation;
		right.EngineTransform.rotation = trans.rotation;
		left.EngineTransform.Rotate(90f,0f,0f);
		right.EngineTransform.Rotate(90f,0f,0f);

		float targetDist = left.enginePair.TargetDistance;

		Vector3 pos = trans.position;
		Vector3 direction = trans.right.normalized;
		right.EngineTransform.position = pos+direction*(targetDist/2f);
		left.EngineTransform.position = pos-direction*(targetDist/2f);

//		transform.Find ("Pod").GetComponent<PlayerNode> ().updateWayPointWhenSpawn (trans);
	}
}
