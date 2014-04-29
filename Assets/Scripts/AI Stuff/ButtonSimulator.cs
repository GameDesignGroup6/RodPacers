using UnityEngine;
using System.Collections;

public class ButtonSimulator : MonoBehaviour {

	public Transform nodeTransform;
	public Node currentNode;
	LeftRightTest test;
	SpawnManager spawn;
	RigidbodyInfo velocityL;
	RigidbodyInfo velocityR;
	NodeRespawn nodeStuffs;
	public float currentPress;
	Vector3 v;
	double x;
	double z;
	double minX;
	double maxX;
	double minZ;
	double maxZ;
	RaycastHit hit;
	float respawnTimer = 0;
	public bool backwards = false;
	public Transform leftEngine;
	public Transform rightEngine;
	public Transform parent;

	void Start () {
		nodeTransform = GameObject.Find("Node1").transform;
		currentNode = nodeTransform.GetComponent<Node>();
		test = GetComponent<LeftRightTest>();
		spawn = parent.GetComponent<SpawnManager>();
		velocityL = leftEngine.GetComponent<RigidbodyInfo>();
		velocityR = rightEngine.GetComponent<RigidbodyInfo>();
		nodeStuffs = GetComponent<NodeRespawn>();
	}

	void Update () {
		currentNode = nodeStuffs.currentNode;
		nodeTransform = nodeStuffs.nodeTransform;
		v = new Vector3((leftEngine.position.x + rightEngine.position.x) / 2, (leftEngine.position.y + rightEngine.position.y) / 2, (leftEngine.position.z + rightEngine.position.z) / 2);
		if (velocityL.Velocity < 11 && velocityR.Velocity < 11)
			respawnTimer+= Time.deltaTime;
		if (respawnTimer > 3) {
			spawn.RespawnAtTransform(currentNode.previous.transform);
			Debug.Log ("Respawn!");
			respawnTimer = 0;
		}
		GetButtons();
	}

	void GetButtons() {
		Vector3 podToNode = new Vector3(currentNode.pos.x - v.x, currentNode.pos.z - v.z);
		Debug.DrawLine(v, currentNode.pos, Color.yellow);
		Debug.DrawRay(v, transform.forward, Color.cyan);
		currentPress = Vector3.Angle(podToNode, transform.forward) / 180;
		if (currentPress < 0.2)
			currentPress = 0;
		if (currentPress > 0.8)
			currentPress = 1;
	}

	void UpdateNode() {
		currentNode = currentNode.next;
		nodeTransform = currentNode.transform;
		test.ChangeNode();
		Debug.Log ("Next node!");
	}
}
