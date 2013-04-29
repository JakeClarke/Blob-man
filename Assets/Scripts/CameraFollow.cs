using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;
	public Vector3 offset = new Vector3(0f, 0f, -100f);
	
	

	
	// Use this for initialization
	void Start () {
	
	}
	
	void Update(){
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		this.transform.position = target.position + offset;
		this.transform.LookAt(new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z));
	}
}
