using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;
	public float distance = 10;
	public float moveAmount = 2;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (transform.position.x - target.position.x < distance){
			transform.Translate(moveAmount * Time.deltaTime, 0, 0);	
		}		
	}
}
