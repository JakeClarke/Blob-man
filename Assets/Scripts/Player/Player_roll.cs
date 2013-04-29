using UnityEngine;
using System.Collections;

public class Player_roll : PlayerBase {
	
	public GameObject PlayerWalking;
	public Vector3 boostForce = new Vector3(30f, 10f, 0f);
	
	public float rollInputSpeed = 0.5f;
	
	private bool _blockToWalk = true;
	
	void Start () {
		base.Start();
		this.rigidbody.AddForce(boostForce, ForceMode.Impulse);
	}
	
	void Update () {
		
		// Allow the player to nudge the rolling.
		if (Input.GetKey(KeyCode.RightArrow))
		{	
			this.rigidbody.AddForce(new Vector3(rollInputSpeed, 0, 0), ForceMode.Acceleration);
		} 
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			this.rigidbody.AddForce(new Vector3(-rollInputSpeed, 0, 0), ForceMode.Acceleration);
		}
		
		if(Input.GetKey(KeyCode.Space) && !_blockToWalk) {
			this.ToWalking();
		}
		else if(!Input.GetKey(KeyCode.Space)) {
			_blockToWalk = false;
		}
	}
	
	public void ToWalking() {
		this.PlayerWalking = (GameObject)Instantiate(this.PlayerWalking, this.transform.position, this.transform.rotation);
		this.PlayerWalking.rigidbody.velocity = this.rigidbody.velocity;
		Destroy(this.gameObject);
	}
}