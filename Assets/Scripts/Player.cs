using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float speed = 2;
	public float jumpAmount = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.RightArrow)){
			if (transform.position.x > 18) {
				//get new speed
				transform.position = new Vector3( -18f, transform.position.y, transform.position.z );
			}
			
			transform.Translate(0, 0, - speed * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.LeftArrow)){
			if (transform.position.x > 18) {
				//get new speed
				transform.position = new Vector3( -18f, transform.position.y, transform.position.z );
			}
			
			transform.Translate(0, 0, speed * Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.UpArrow)){
			if (transform.position.x > 18) {
				//get new speed
				transform.position = new Vector3( -18f, transform.position.y, transform.position.z );
			}
			
			transform.Translate(0, jumpAmount * Time.deltaTime, 0);
		}
		
	}
}
