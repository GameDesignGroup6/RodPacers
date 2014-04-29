using UnityEngine;
using System.Collections;

public class NodeRespawn : MonoBehaviour {

	public Transform nodeTransform;
	public Node currentNode;
	LeftRightTest test;
	double x;
	double z;
	double minX;
	double maxX;
	double minZ;
	double maxZ;
	
	void Start () {
		nodeTransform = GameObject.Find("Node1").transform;
		currentNode = nodeTransform.GetComponent<Node>();
		test = GetComponent<LeftRightTest>();
	}

	void Update () {
//		DebugHUD.setValue(transform.parent.name+"/"+name+" distance",currentNode.DistanceFromStart+Vector3.Distance(transform.position,nodeTransform.position));
		x = currentNode.pos.x;
		z = currentNode.pos.z;
		minX = x - 100;
		maxX = x + 100;
		minZ = z - 100;
		maxZ = z + 100;
		if (transform.position.x > minX && transform.position.x < maxX && transform.position.z > minZ && transform.position.z < maxZ)
			UpdateNode();
		if (currentNode.branch != null && currentNode.pos.y - transform.position.y >= 80) {
			currentNode = currentNode.branch;
			nodeTransform = currentNode.transform;
			if (test != null)
				test.ChangeNode();
		}
	}

	void UpdateNode() {
		currentNode = currentNode.next;
		nodeTransform = currentNode.transform;
		if (test != null)
			test.ChangeNode();
	}
}
