using UnityEngine;
using System.Collections;

public class ButtonSimulator : MonoBehaviour {

	public Transform nodeTransform;
	public Node currentNode;
	LeftRightTest test;
	public float currentPress;
	Vector3 v;
	double x;
	double z;
	double minX;
	double maxX;
	double minZ;
	double maxZ;
	RaycastHit hit;
	public bool backwards = false;
	public Transform leftEngine;
	public Transform rightEngine;
	public Transform parent;

	void Start () {
		nodeTransform = GameObject.Find("Node1").transform;
		currentNode = nodeTransform.GetComponent<Node>();
		test = GetComponent<LeftRightTest>();
	}

	void Update () {
		v = new Vector3((leftEngine.position.x + rightEngine.position.x) / 2, (leftEngine.position.y + rightEngine.position.y) / 2, (leftEngine.position.z + rightEngine.position.z) / 2);
		x = currentNode.pos.x;
		z = currentNode.pos.z;
		minX = x - 100;
		maxX = x + 100;
		minZ = z - 100;
		maxZ = z + 100;
		if (v.x > minX && v.x < maxX && v.z > minZ && v.z < maxZ)
			UpdateNode();
		if (currentNode.branch != null && currentNode.pos.y - v.y >= 80) {;
			currentNode = currentNode.branch;
			nodeTransform = currentNode.transform;
			test.ChangeNode();
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
