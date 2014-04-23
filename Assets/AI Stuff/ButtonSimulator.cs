using UnityEngine;
using System.Collections;

public class ButtonSimulator : MonoBehaviour {

	public Transform nodeTransform;
	public Node currentNode;
	LeftRightTest test;
	public float currentPress;

	// Use this for initialization
	void Start () {
		currentNode = nodeTransform.GetComponent<Node>();
		test = GetComponent<LeftRightTest>();
	}
	
	// Update is called once per frame
	void Update () {
		double x = currentNode.pos.x;
		double z = currentNode.pos.z;
		double minX = x - 2;
		double maxX = x + 2;
		double minZ = z - 2;
		double maxZ = z + 2;
		if (transform.position.x > minX && transform.position.x < maxX && transform.position.z > minZ && transform.position.z < maxZ)
			UpdateNode();
		GetButtons();
	}

	void GetButtons() {
		Vector3 podToNode = new Vector3(currentNode.pos.x - transform.position.x, currentNode.pos.z - transform.position.z);
		Vector3 podForward = transform.forward;
		Debug.DrawLine(transform.position, currentNode.pos);
		Debug.DrawRay(transform.position, transform.forward);
		currentPress = Vector3.Angle(podToNode, podForward) / 180;
		Debug.Log (currentPress.ToString ());
	}

	void UpdateNode() {
		currentNode = currentNode.next;
		nodeTransform = currentNode.transform;
		test.ChangeNode();
		Debug.Log ("Next node!");
	}
}
