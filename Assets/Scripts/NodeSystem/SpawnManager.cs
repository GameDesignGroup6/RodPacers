﻿using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
	private Engine left,right;
	private Transform lastCheckpoint;
	public bool isAI = false;

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
	}
	public void updateCheckpoint(Transform c){
		lastCheckpoint = c;
	}
	public void respawnAtLastCheckpoint(){
		if(isAI){
			RespawnAtTransform(GetComponentInChildren<NodeRespawn>().currentNode.previous.transform);
			return;
		}
		if(lastCheckpoint!=null){
			RespawnAtTransform(lastCheckpoint);
		}
	}

	public void RespawnAtTransform(Transform trans){
		left.EngineHealth.SendMessage("Start");
		right.EngineHealth.SendMessage("Start");

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
