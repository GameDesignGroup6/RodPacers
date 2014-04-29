using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class bouncySpinnyNodeScript : MonoBehaviour {

	Quaternion quart;

	void Start () {
		Node[] array = GetComponentsInChildren<Node>();
		for (int i = 0; i < array.Length; i++) {
			if (array[i].next != null) {
				quart = Quaternion.LookRotation(array[i].next.transform.position - array[i].transform.position, Vector3.up);
				array[i].transform.rotation = quart;
			}
		}
	}
}
