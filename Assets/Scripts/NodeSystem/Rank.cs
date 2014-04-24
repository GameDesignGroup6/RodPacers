using UnityEngine;
using System.Collections;
[RequireComponent(typeof(GUIText))]
public class Rank : MonoBehaviour {
	public Transform[] podRacer; //1st element of array would rank first, etc..
	private int NumPod; //total number of pods
	public Transform currentPlayer;

	void Start () {
		NumPod = podRacer.Length;
	}
	void Update () {
			guiText.text = currentPlayer.GetComponent<PlayerNode> ().position.ToString ();
		bubbleSort (podRacer, NumPod);
		//assign position by array's position
			for (int i = 0; i<NumPod; i++) {
					podRacer [i].GetComponent<PlayerNode>().position = i + 1;

				}
		}

	//sort by PodRace array by each's current waypoint, if having same waypoint then compare distance to next waypoint
	//credit to eecs 233 slide
	 void bubbleSort(Transform[] arr, int length) {
			for(int i=length-1;i>0; i--){
			for (int j = 0; j < i; j++) {
					if (arr[j].GetComponent<PlayerNode>().currentWayPoint.GetComponent<NodeA>().rank<arr[j+1].GetComponent<PlayerNode>().currentWayPoint.GetComponent<NodeA>().rank)
					 swap(arr, j, j+1);
				else if (arr[j].GetComponent<PlayerNode>().currentWayPoint.GetComponent<NodeA>().rank==arr[j+1].GetComponent<PlayerNode>().currentWayPoint.GetComponent<NodeA>().rank)
					if (arr[j].GetComponent<PlayerNode>().getDistanceToNextPoint()>arr[j+1].GetComponent<PlayerNode>().getDistanceToNextPoint())
						swap (arr,j,j+1);
			}
		}
	}

	void swap(Transform[] arr, int i, int j){
				Transform temp;
				temp = arr [i];
				arr [i] = arr [j];
				arr [j] = temp;
		}	
}
