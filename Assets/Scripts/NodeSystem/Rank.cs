using UnityEngine;
using System.Collections;
[RequireComponent(typeof(GUIText))]
public class Rank : MonoBehaviour {
	public Transform[] podRacer; //last element of array would rank first, etc..
	private int numPod; //total number of pods
	public int notFinishedPod; //number of pods not finished yet
	public Transform currentPlayer;
	public int totalLap;
	public bool finish;
	void Start () {
		numPod = podRacer.Length;
		notFinishedPod = numPod;

	}
	void Update () {
		if (!finish)
			guiText.text = currentPlayer.GetComponent<PlayerNode> ().position.ToString ();
		bubbleSort (podRacer, notFinishedPod);
		//assign position by array's position
		int j = numPod;
		for (int i = 0; i<notFinishedPod; i++) {
						podRacer [i].GetComponent<PlayerNode> ().position = j;
						j--;
				}				
		}

	//sort by PodRace array by each's current waypoint, if having same waypoint then compare distance to next waypoint
	//credit to eecs 233 slide
	//1. compare lap 2. compare way point 3. if 1,2 same, compare distance to nextwaypoint
	 void bubbleSort(Transform[] arr, int length) {
			for(int i=length-1;i>0; i--){
			for (int j = 0; j < i; j++) {
					if (arr[j].GetComponent<PlayerNode>().currentLap>arr[j+1].GetComponent<PlayerNode>().currentLap)
					swap(arr, j, j+1);
				else if (arr[j].GetComponent<PlayerNode>().currentLap==arr[j+1].GetComponent<PlayerNode>().currentLap)
					if (arr[j].GetComponent<PlayerNode>().currentWayPoint.GetComponent<NodeA>().rank>arr[j+1].GetComponent<PlayerNode>().currentWayPoint.GetComponent<NodeA>().rank)
					 swap(arr, j, j+1);
				else if (arr[j].GetComponent<PlayerNode>().currentWayPoint.GetComponent<NodeA>().rank==arr[j+1].GetComponent<PlayerNode>().currentWayPoint.GetComponent<NodeA>().rank)
					if (arr[j].GetComponent<PlayerNode>().getDistanceToNextPoint()<arr[j+1].GetComponent<PlayerNode>().getDistanceToNextPoint())
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
	void end(){
			//	const string finishTime = currentPlayer.GetComponent<PlayerNode> ().position.ToString () + "finishTime:" +
			//			"<color=yellow>" + (int)(Time.timeSinceLevelLoad / 60) + ":" + (int)((Time.timeSinceLevelLoad % 60) / 10)
			//			+ (int)((Time.timeSinceLevelLoad % 60) % 10) + ":" + (int)(Time.timeSinceLevelLoad % 1 * 10) + (int)(Time.timeSinceLevelLoad % .1 * 100)
			//			+ (int)(Time.timeSinceLevelLoad % .01 * 1000) + "</color>";
			//	guiText.text = finishTime;
		}
}
