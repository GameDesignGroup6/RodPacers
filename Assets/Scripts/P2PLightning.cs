using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
[ExecuteInEditMode]
public class P2PLightning : MonoBehaviour {
	[HideInInspector][System.NonSerialized]
	public bool r = false,g = false,b = false;
	private LineRenderer lr;
	public int numPoints;
	public Vector3 targetPoint;
	public Transform targetTransform;
	public AnimationCurve curve;
	public enum TargetMode{Point,Transform}
	public TargetMode targetMode;

#if UNITY_EDITOR
	private Vector3[] curPosA,firstAxisA,secondAxisA;

#endif

	//i'm going to make some of my variables used in UpdateSettings()
	//fields so that I don't have to allocate extra memory
	private float delta,percent;
	private Vector3 forward,curPos,forward2,firstAxis,secondAxis,thisPos;


	private Transform trans;
	// Use this for initialization
	void Start () {
		if(targetMode==TargetMode.Transform&&targetTransform==null)targetMode = TargetMode.Point;
		trans = transform;

#if UNITY_EDITOR
		curPosA = new Vector3[numPoints+1];
		firstAxisA = new Vector3[numPoints+1];
		secondAxisA = new Vector3[numPoints+1];
#endif

	}
	void UpdateRenderer(){
		if(lr==null)lr = GetComponent<LineRenderer>();
		if(targetMode==TargetMode.Transform){
			targetPoint = targetTransform.position;
		}
		lr.SetVertexCount(numPoints+1);
		delta = Vector3.Distance(trans.position,targetPoint)/((float)numPoints);
		lr.SetPosition(0,trans.position);
		forward = Vector3.Normalize(targetPoint-trans.position)*delta;		
		curPos = trans.position;
		for(int i = 1; i<=numPoints;i++){
			percent = ((float)i)/((float)numPoints+1);
			curPos+=forward;
			forward2 = forward;
			firstAxis = Vector3.Normalize(Vector3.Cross(forward2,Vector3.up));
			secondAxis = Vector3.Normalize(Vector3.Cross (firstAxis,forward2));
			firstAxis*=Random.Range(-1f,1f);
			firstAxis*=curve.Evaluate(percent);
			secondAxis*=Random.Range (-1f,1f);
			secondAxis*=curve.Evaluate(percent);
#if UNITY_EDITOR
			curPosA[i] = curPos;
			firstAxisA[i] = firstAxis;
			secondAxisA[i] = secondAxis;
#endif
			thisPos = curPos+firstAxis+secondAxis;
			lr.SetPosition(i,thisPos);
			if(i==numPoints){
				lr.SetPosition(i,targetPoint);
			}
		}
	}
	void OnBecameInvisible(){
		enabled = false;
	}
	void OnBecameVisible(){
		enabled = true;
	}


#if UNITY_EDITOR
	void OnDrawGizmos(){
		if(!(r||g||b))return;
		for(int i = 0; i<=numPoints;i++){
			if(r){
				Gizmos.color = Color.red;
				Gizmos.DrawRay(curPosA[i],firstAxisA[i]);
			}
			if(b){
				Gizmos.color = Color.blue;
				Gizmos.DrawRay(curPosA[i],secondAxisA[i]);
			}
			if(g){
				Gizmos.color = Color.green;
				Gizmos.DrawRay(curPosA[i],firstAxisA[i]+secondAxisA[i]);
			}
		}
	}
#endif	


	void Update(){
#if (!UNITY_EDITOR)
		UpdateRenderer();
#else
		if(UnityEditor.EditorApplication.isPlaying)UpdateRenderer();
#endif
	}
}
