using UnityEngine;
using System.Collections;

public class PodSkin : MonoBehaviour {
	public Transform basePod,baseLeft,baseRight;
	private GameObject curPod,curLeft,curRight;
	public bool ChangeOnStart;
	public int initialSkinIndex = 0;

	void Start(){
		if(ChangeOnStart)ChangeSkin(initialSkinIndex);
	}

	void Update(){
		if(Input.GetKey(KeyCode.F2)){
			for(int i = 0; i<SkinManager.SkinList.Length;i++){
				if(Input.GetKeyDown((i).ToString())){
					ChangeSkin(i);
				}
			}
		}
	}
	public void ChangeSkin(int index){
		ChangeSkin(SkinManager.SkinList[index]);
	}
	public void ChangeSkin(string skin){
		Deskin();
		GameObject newPod = Resources.Load<GameObject>("Pods/"+skin+"/Pod");
		GameObject newLeft = Resources.Load<GameObject>("Pods/"+skin+"/Left");
		GameObject newRight = Resources.Load<GameObject>("Pods/"+skin+"/Right");
		if(newPod!=null){
			curPod = Instantiate(newPod,basePod.position,basePod.rotation)as GameObject;
			Transform newLeftMount = curPod.transform.Find ("LeftMount");
			if(newLeftMount!=null){
				Transform oldLeftMount = basePod.Find("LeftMount");
				if(oldLeftMount!=null)oldLeftMount.position = newLeftMount.position;
			}
			Transform newRightMount = curPod.transform.Find ("RightMount");
			if(newRightMount!=null){
				Transform oldRightMount = basePod.Find("RighttMount");
				if(oldRightMount!=null)oldRightMount.position = newRightMount.position;
			}
			basePod.renderer.enabled = false;
			curPod.transform.parent = basePod;
		}
		if(newLeft!=null){
			curLeft = Instantiate(newLeft,baseLeft.position,baseLeft.rotation)as GameObject;
			Transform newDecLink = curLeft.transform.Find ("Decorative_Link");
			if(newDecLink!=null){
				Transform oldDecLink = baseLeft.Find("Decorative_Link");
				if(oldDecLink!=null)oldDecLink.position = newDecLink.position;
			}
			baseLeft.renderer.enabled = false;
			curLeft.transform.parent = baseLeft;
		}
		if(newRight!=null){
			curRight = Instantiate(newRight,baseRight.position,baseRight.rotation)as GameObject;
			Transform newDecLink = curRight.transform.Find ("Decorative_Link");
			if(newDecLink!=null){
				Transform oldDecLink = baseRight.Find("Decorative_Link");
				if(oldDecLink!=null)oldDecLink.position = newDecLink.position;
			}
			baseRight.renderer.enabled = false;
			curRight.transform.parent = baseRight;
		}
	}
	public void Deskin(){
		GameObject podToKill = curPod;
		GameObject leftToKill = curLeft;
		GameObject rightToKill = curRight;
		
		//oo! kill 'em
		if(podToKill!=null)DestroyImmediate(podToKill);
		if(leftToKill!=null)DestroyImmediate(leftToKill);
		if(rightToKill!=null)DestroyImmediate(rightToKill);

		curPod = curLeft = curRight = null;

		basePod.renderer.enabled = true;
		baseLeft.renderer.enabled = true;
		baseRight.renderer.enabled = true;

		Resources.UnloadUnusedAssets();
	}
}
