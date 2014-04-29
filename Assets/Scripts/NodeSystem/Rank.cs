using UnityEngine;
using System.Collections;
//there should be only one rank object with this script in scene, possibly multiple showRank object
public class Rank : MonoBehaviour {
	public Transform[] podRacer; //last element of array would rank first, etc..
	private int numPod; //total number of pods
	public int notFinishedPod; //number of pods not finished yet
	public int totalLap;
	public bool finish;
	public string[,] leaderBoard;

	void Start () {
	//	print (Application.loadedLevelName);
		numPod = podRacer.Length;
		notFinishedPod = podRacer.Length;
		leaderBoard=new string[numPod,3];
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Update () {
		if (finish) {
			for (int i = 0; i<numPod; i++) {
				if (podRacer[0]==null)
					return;
				leaderBoard [i, 0] = podRacer [i].parent.name;
				leaderBoard [i, 1] = podRacer [i].GetComponent<PlayerNode> ().finishTime;
				leaderBoard [i, 2] = podRacer [i].GetComponent<PlayerNode> ().position.ToString ();
			}
			Application.LoadLevel ("FinishScene");
		} else {
			bubbleSort (podRacer, notFinishedPod);
			//assign position by array's position
			int j = numPod;
			for (int i = 0; i<notFinishedPod; i++) {
				podRacer [i].GetComponent<PlayerNode> ().position = j;
				j--;
			}		
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

	// when  all pod finished
	public void checkFinsh(){
		foreach (Transform pod in podRacer)
			if (!pod.GetComponent<PlayerNode> ().finished)
								return;
		for (int i = 0; i<numPod; i++) {
				leaderBoard [i,0] = podRacer[i].parent.name;
				leaderBoard [i,1] = podRacer[i].GetComponent<PlayerNode> ().finishTime;
				leaderBoard [i,2] = podRacer[i].GetComponent<PlayerNode> ().position.ToString();
				}
		Application.LoadLevel ("FinishScene");
		}
}
