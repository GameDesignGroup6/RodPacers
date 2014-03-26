using UnityEngine;
using System.Collections;

public class PodSkin : MonoBehaviour {
	public Transform basePod,baseLeft,baseRight;
	private GameObject curPod,curLeft,curRight;
	public bool ChangeOnStart;
	public string initialSkin;

	void Start(){
		if(ChangeOnStart)ChangeSkin(initialSkin);
	}

	public void ChangeSkin(string skin){
		Deskin();
		Debug.Log("loading skin "+skin);
		GameObject newPod = Resources.Load<GameObject>("Pods/"+skin+"/Pod");
		GameObject newLeft = Resources.Load<GameObject>("Pods/"+skin+"/Left");
		GameObject newRight = Resources.Load<GameObject>("Pods/"+skin+"/Right");
		if(newPod!=null){
			curPod = Instantiate(newPod,basePod.position,basePod.rotation)as GameObject;
			basePod.renderer.enabled = false;
			curPod.transform.parent = basePod;
		}
		if(newLeft!=null){
			curLeft = Instantiate(newLeft,baseLeft.position,baseLeft.rotation)as GameObject;
			baseLeft.renderer.enabled = false;
			curLeft.transform.parent = baseLeft;
		}
		if(newRight!=null){
			curRight = Instantiate(newRight,baseRight.position,baseRight.rotation)as GameObject;
			baseRight.renderer.enabled = false;
			curRight.transform.parent = baseRight;
		}
	}
	public void Deskin(){
		GameObject podToKill = curPod;
		GameObject leftToKill = curLeft;
		GameObject rightToKill = curRight;
		
		//oo! kill 'em!
		if(podToKill!=null)DestroyImmediate(podToKill);
		if(leftToKill!=null)DestroyImmediate(leftToKill);
		if(rightToKill!=null)DestroyImmediate(rightToKill);

		curPod = curLeft = curRight = null;

		basePod.renderer.enabled = true;
		baseLeft.renderer.enabled = true;
		baseRight.renderer.enabled = true;
	}
}
