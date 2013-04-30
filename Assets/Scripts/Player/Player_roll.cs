using UnityEngine;
using System.Collections;

public class Player_roll : PlayerBase {
	
	public GameObject PlayerWalking;
	
	public float rollInputSpeed = 500;
	public float rollDuration = 0.5f;
	
	public float rightAngle = 270;
	public float leftAngle = 90;
	
	new void Start () {
		base.Start();
		
		// Check the direction of the player
		if (this.transform.eulerAngles.y < rightAngle)
		{
			rollInputSpeed = -rollInputSpeed;
		}
	}
	
	void Update () {
			
		this.rigidbody.AddForce(new Vector3(rollInputSpeed, 0, 0), ForceMode.Impulse);
		rollDuration -= Time.deltaTime;
		if (rollDuration <= 0)
		{
			this.ToWalking();	
		}
		
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Wall") {
			// collision.gameObject.SendMessage("onHit");	
		}
	}
	
	public void ToWalking() {
		// Reset the rotation
		float rotation = (rollInputSpeed < 0) ? leftAngle : rightAngle;
		this.transform.eulerAngles = new Vector3(0, rotation, 0);
		
		this.PlayerWalking = (GameObject)Instantiate(this.PlayerWalking, this.transform.position, this.transform.rotation);
		this.PlayerWalking.rigidbody.velocity = this.rigidbody.velocity;
		Destroy(this.gameObject);
	}
}