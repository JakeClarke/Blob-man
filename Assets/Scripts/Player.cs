using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float speed = 2;
	public Vector3 jumpAmount;
	public float rightAngle = 270;
	public float leftAngle = 90;
	
	
	private bool onGround;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.RightArrow)){	
			
			if (transform.eulerAngles.y != rightAngle){
				transform.eulerAngles = new Vector3(0, rightAngle, 0);
			}
			
			
			transform.Translate(0, 0, - speed * Time.deltaTime);
			
		} else if (Input.GetKey(KeyCode.LeftArrow)){
			
			if (transform.eulerAngles.y != leftAngle){
				transform.eulerAngles = new Vector3(0, leftAngle, 0);
			}
			
			transform.Translate(0, 0, - speed * Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.UpArrow) && onGround == true){
			//transform.Translate(0, jumpAmount * Time.deltaTime, 0);
			rigidbody.AddForce(jumpAmount, ForceMode.VelocityChange);
			onGround = false;
		}
		
	}
	
	void FixedUpdate() {
		
	}
	
	void OnCollisionEnter(Collision collision){
		onGround = true;
	}
	
	void OnCollisionExit() {
		onGround = false;	
	}
}
