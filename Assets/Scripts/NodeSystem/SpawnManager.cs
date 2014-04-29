using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
	private Engine left,right;

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

	public void RespawnAtTransform(Transform trans){
		left.EngineHealth.SendMessage("Start");
		right.EngineHealth.SendMessage("Start");

		left.EngineRigidbody.velocity = Vector3.zero;
		right.EngineRigidbody.velocity = Vector3.zero;
		left.EngineRigidbody.angularVelocity = Vector3.zero;
		right.EngineRigidbody.angularVelocity = Vector3.zero;

		left.EngineTransform.rotation = trans.rotation;
		right.EngineTransform.rotation = trans.rotation;

		float targetDist = left.enginePair.TargetDistance;

		Vector3 pos = trans.position;
		Vector3 direction = trans.right.normalized;
		right.EngineTransform.position = pos+direction*(targetDist/2f);
		left.EngineTransform.position = pos-direction*(targetDist/2f);
		Debug.Log("Should have respawned!");
	}
}
