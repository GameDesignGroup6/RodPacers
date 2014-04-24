using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EngineThruster),typeof(EngineHealth),typeof(RigidbodyInfo))]
[RequireComponent(typeof(HoverScript),typeof(WobbleGenerator),typeof(Rigidbody))]
public class Engine : MonoBehaviour {
	public EnginePair enginePair;
	public Transform FrontLink,RearLink,DecorativeLink;
	public EngineSide Side;
	private EngineThruster thruster;
	public EngineThruster EngineThruster{
		get{return thruster;}
	}
	private EngineHealth health;
	public EngineHealth EngineHealth{
		get{return health;}
	}
	private RigidbodyInfo info;
	public RigidbodyInfo RigidbodyInfo{
		get{return info;}
	}
	private HoverScript hoverScript;
	public HoverScript HoverScript{
		get{return hoverScript;}
	}
	private WobbleGenerator wobbleGenerator;
	public WobbleGenerator WobbleGenerator{
		get{return wobbleGenerator;}
	}
	private Transform trans;
	public Transform EngineTransform{
		get{return trans;}
	}
	private Rigidbody rgb;
	public Rigidbody EngineRigidbody{
		get{return rgb;}
	}
	public Vector3 TransformPosition{
		get{return trans.position;}
	}
	public float Veloctiy{
		get{return info.Velocity;}
	}

	void Awake(){
		thruster = GetComponent<EngineThruster>();
		health = GetComponent<EngineHealth>();
		info = GetComponent<RigidbodyInfo>();
		hoverScript = GetComponent<HoverScript>();
		wobbleGenerator = GetComponent<WobbleGenerator>();
		trans = transform;
		rgb = rigidbody;
	}
	public enum EngineSide{
		LEFT,RIGHT
	}	
}
