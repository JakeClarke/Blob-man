using UnityEngine;
using System.Collections;

public class Player_roll : PlayerBase {
	
	public GameObject PlayerWalking;
	
	public float rollInputSpeed = 500;
	public float rollDuration = 0.5f;
	
	void Start () {
		base.Start();
	}
	
	void Update () {
		
		// Allow the player to nudge the rolling.
		/*
		if (Input.GetKey(KeyCode.RightArrow))
		{	
			this.rigidbody.AddForce(new Vector3(rollInputSpeed, 0, 0), ForceMode.Acceleration);
		} 
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			this.rigidbody.AddForce(new Vector3(-rollInputSpeed, 0, 0), ForceMode.Acceleration);
		}
		
		if(Input.GetKey(KeyCode.Space)) {
			this.ToWalking();
		}*/
		
		this.rigidbody.AddForce(new Vector3(rollInputSpeed, 0, 0), ForceMode.Impulse);
		rollDuration -= Time.deltaTime;
		if (rollDuration <= 0)
		{
			this.ToWalking();	
		}
		
	}
	
	public void ToWalking() {
		this.PlayerWalking = (GameObject)Instantiate(this.PlayerWalking, this.transform.position, this.transform.rotation);
		this.PlayerWalking.rigidbody.velocity = this.rigidbody.velocity;
		Destroy(this.gameObject);
	}
}