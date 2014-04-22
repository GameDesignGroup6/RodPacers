using UnityEngine;
using System.Collections;

public class MovingAI : PodScript {
	private float speed;
	// Use this for initialization
	void Start () {
		speed = 20;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, goalNode.Position, speed*Time.deltaTime);
	}

	//Vector3 difference (){
	//	return goalNode.Position - currentNode.Position;
	//}
}
