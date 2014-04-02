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
		Debug.Log("loading skin "+skin);
		GameObject newPod = Resources.Load<GameObject>("Pods/"+skin+"/Pod");
		GameObject newLeft = Resources.Load<GameObject>("Pods/"+skin+"/Left");
		GameObject newRight = Resources.Load<GameObject>("Pods/"+skin+"/Right");
		if(newPod!=null){
			Debug.Log("Pod found!");
			curPod = Instantiate(newPod,basePod.position,basePod.rotation)as GameObject;
			basePod.renderer.enabled = false;
			curPod.transform.parent = basePod;
		}else Debug.Log ("Pod not found, reverting to default");
		if(newLeft!=null){
			Debug.Log("Left found!");
			curLeft = Instantiate(newLeft,baseLeft.position,baseLeft.rotation)as GameObject;
			baseLeft.renderer.enabled = false;
			curLeft.transform.parent = baseLeft;
		}else Debug.Log ("Left not found, reverting to default");
		if(newRight!=null){
			Debug.Log("Right found!");
			curRight = Instantiate(newRight,baseRight.position,baseRight.rotation)as GameObject;
			baseRight.renderer.enabled = false;
			curRight.transform.parent = baseRight;
		}else Debug.Log ("Right not found, reverting to default");
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
