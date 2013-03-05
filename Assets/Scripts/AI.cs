using UnityEngine;
using System.Collections;
using System;

public class AI : MonoBehaviour {
	
	public float speed = 4;
	public float distanceToMove = 10;
	
	private float startPoint;

	// Use this for initialization
	void Start () {
		startPoint = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.x - startPoint >= distanceToMove){
			speed = -speed;
		} else if ( startPoint - transform.position.x >= distanceToMove) {
			speed = -speed;
		}
		
		transform.Translate(speed * Time.deltaTime, 0, 0);
	}
	
	void FixedUpdate(){	
		
	}
	
}
