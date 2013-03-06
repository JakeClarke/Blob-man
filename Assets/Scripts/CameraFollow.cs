using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;
	public float distance = 10;
	public float moveAmount = 2;
	public float fastForward = 12;
	public float fastForwardDelay = 1;
	
	
	private bool moveRight = true;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void Update(){
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			moveRight = true;
		} else if (Input.GetKeyDown(KeyCode.LeftArrow)){
			moveRight = false;	
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (moveRight){
			if (transform.position.x - target.position.x < distance){
				if (transform.position.x - target.position.x < distance - fastForwardDelay){
					transform.Translate(fastForward * Time.deltaTime, 0, 0);	
				} else {
					transform.Translate(moveAmount * Time.deltaTime, 0, 0);	
				}
			}		
		} else {
			if (target.position.x - transform.position.x < distance){
				if (target.position.x - transform.position.x < distance - fastForwardDelay){
					transform.Translate(-fastForward * Time.deltaTime, 0, 0);	
				} else {
					transform.Translate(-moveAmount * Time.deltaTime, 0, 0);	
				}
			}	
		}
	}
}
