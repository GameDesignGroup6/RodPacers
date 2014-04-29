﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider),typeof(Engine))]
public class EngineHealth : MonoBehaviour {
	public float maxHealth = 1000f;
	private float curHealth;
	public float Health{
		get{return curHealth;}
	}
	private float inv = 0f;
	private bool dead = false;
	public bool Dead{
		get{return dead;}
	}

	void Start(){
		curHealth = maxHealth;
	}

	void OnCollisionStay(Collision col){
		curHealth-=0.5f;
	}
	void OnCollisionEnter(Collision col){
		if(inv>0f)return;
		inv = 0.25f;
		Vector3 velocity = col.relativeVelocity;
		Vector3 normal = col.contacts[0].normal;
		float speed = Vector3.Project(velocity,normal).magnitude;
		float damage = speed;
		Debug.Log ("HIT speed: "+speed+", damage: "+damage);
		Hurt(damage*damage*5f);
	}

	void FixedUpdate(){
		if(inv>0.0f){
			inv-=Time.fixedDeltaTime;
			if(inv<0f)inv=0f;
		}
	}
	public void Hurt(float damage){
		curHealth-=damage;
		if(curHealth<=0f){
			Engine e = GetComponent<Engine>();
			e.HoverScript.enabled = false;
			e.EngineThruster.enabled = false;
			dead = true;
			if(e.OtherEngine.EngineHealth.Dead){
				transform.parent.GetComponent<SpawnManager>().RespawnAtTransform(transform.parent.FindChild("Pod").GetComponent<NodeRespawn>().currentNode.previous.transform);
			}

		}
	}
}