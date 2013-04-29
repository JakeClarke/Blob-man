using UnityEngine;
using System.Collections;

public class Player : PlayerBase {
	
	public GameObject PlayerRolling;
	
	public float speed = 2;
	public float jumpAmount = 10f;
	public float rightAngle = 270;
	public float leftAngle = 90;
	
	
	private bool onGround;
	private bool rolling;
	private float CameraDistanceY;
	
	// Use this for initialization
	void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		// -----------------------------------------------------
		//
		//		Movements
		//
		// -----------------------------------------------------
		
		if (Input.GetKey(KeyCode.RightArrow))
		{	
			
			if (transform.eulerAngles.y != rightAngle)
			{
				transform.eulerAngles = new Vector3(0, rightAngle, 0);
			}
			
			
			transform.Translate(0, 0, - speed * Time.deltaTime);
			
		} 
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			
			if (transform.eulerAngles.y != leftAngle){
				transform.eulerAngles = new Vector3(0, leftAngle, 0);
			}
			
			transform.Translate(0, 0, - speed * Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.UpArrow) && onGround == true)
		{
			//transform.Translate(0, jumpAmount * Time.deltaTime, 0);
			rigidbody.AddForce(new Vector3(0, jumpAmount, 0), ForceMode.Impulse);
			onGround = false;
		}
		
		// thinking about making it so the player has to go through a world element to switch to ball mode.
		if(Input.GetKey(KeyCode.Space)) {
			this.ToRolling();
		}
	}
	
	void FixedUpdate() {
		DetectGround();
	}
	
	void OnCollisionEnter(Collision collision)
	{
		// Debug.Log (collision.gameObject.name);
		
		// only ground if the player is above the object.
		if(collision.contacts[0].normal.y > 0.5) {
			//onGround = true;
			if(collision.gameObject.tag == "Enemy") {
				Debug.Log ("Player hit: " + collision.gameObject.name);
				collision.gameObject.SendMessage("onHit");
			}
		}
		
		if(collision.gameObject.tag == "enemy") {
			GameOver();
		}
		
	}
	
	public void ToRolling() {
		this.PlayerRolling = (GameObject)Instantiate(this.PlayerRolling, this.transform.position, this.transform.rotation);
		this.PlayerRolling.rigidbody.velocity = this.rigidbody.velocity;
		Destroy(this.gameObject);
	}
	
	void GameOver() {
		// game over, man, game over.
		Debug.Log ("Game over.");
	}
	
	void DetectGround() {
		Vector3 rayOrigin = this.transform.position + new Vector3(0f, 0.1f, 0f);
		float rayLength = 0.5f;
		
	    RaycastHit[] hits;
        hits = Physics.RaycastAll (rayOrigin, -Vector3.up, rayLength);
        // Change the material of all hit colliders
        // to use a transparent Shader
        for (var i = 0;i < hits.Length; i++) {
            RaycastHit hit = hits[i];
			if(hit.collider. tag != "Player") {
				this.onGround = true;
			}
        }
		
		Debug.DrawRay (rayOrigin, -Vector3.up * rayLength, (this.onGround) ? Color.green : Color.red);
	}
}
