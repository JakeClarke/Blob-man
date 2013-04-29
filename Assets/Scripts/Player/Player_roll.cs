using UnityEngine;
using System.Collections;

public class Player_roll : PlayerBase {
	
	public GameObject PlayerWalking;
	public Vector3 boostForce = new Vector3(30f, 10f, 0f);
	
	public float rollInputSpeed = 500;
	public float rollDuration = 0.5f;
	
	public float rightAngle = 270;
	public float leftAngle = 90;
	
	private bool _blockToWalk = true;
	
	void Start () {
		base.Start();
<<<<<<< HEAD:Assets/Scripts/Player_roll.cs
		
		// Check the direction of the player
		if (this.transform.eulerAngles.y < rightAngle)
		{
			rollInputSpeed = -rollInputSpeed;
		}
=======
		this.rigidbody.AddForce(boostForce, ForceMode.Impulse);
>>>>>>> 6e70b4d1e613870d84292e5843c83a12745b2ed7:Assets/Scripts/Player/Player_roll.cs
	}
	
	void Update () {
			
		this.rigidbody.AddForce(new Vector3(rollInputSpeed, 0, 0), ForceMode.Impulse);
		rollDuration -= Time.deltaTime;
		if (rollDuration <= 0)
		{
			this.ToWalking();	
		}
		
<<<<<<< HEAD:Assets/Scripts/Player_roll.cs
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Wall") {
			collision.gameObject.SendMessage("onHit");	
=======
		if(Input.GetKey(KeyCode.Space) && !_blockToWalk) {
			this.ToWalking();
>>>>>>> 6e70b4d1e613870d84292e5843c83a12745b2ed7:Assets/Scripts/Player/Player_roll.cs
		}
		else if(!Input.GetKey(KeyCode.Space)) {
			_blockToWalk = false;
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