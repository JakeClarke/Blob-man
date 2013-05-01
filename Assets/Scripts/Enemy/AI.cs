using UnityEngine;
using System.Collections;
using System;

public class AI : MonoBehaviour {
	
	public float speed = 4;
	public float distanceToMove = 10;
	
	private const float _RIGHTANGLE = 180;
	private const float _LEFTANGLE = 0;
	
	private float startPoint;

	// Use this for initialization
	void Start () {
		startPoint = transform.position.x;
		transform.eulerAngles = new Vector3(0, _LEFTANGLE, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.x - startPoint >= distanceToMove){
			transform.eulerAngles = new Vector3(0, _LEFTANGLE, 0);
		} else if ( startPoint - transform.position.x >= distanceToMove) {
			transform.eulerAngles = new Vector3(0, _RIGHTANGLE, 0);
		}
		
		transform.Translate(-speed * Time.deltaTime, 0, 0);
	}
	
	void FixedUpdate(){	
		
	}
	
}
