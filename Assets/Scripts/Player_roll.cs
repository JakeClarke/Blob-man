using UnityEngine;
using System.Collections;

public class Player_roll : MonoBehaviour {
	
	public GameObject PlayerWalking;
	
	public float rollInputSpeed = 0.5f;
	
	void Start () {
		
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
		
		if(Input.GetKey(KeyCode.Space)) {
			this.ToWalking();
		}
	}
	
	public void ToWalking() {
		this.PlayerWalking = (GameObject)Instantiate(this.PlayerWalking, this.transform.position, this.transform.rotation);
		this.PlayerWalking.rigidbody.velocity = this.rigidbody.velocity;
		Destroy(this.gameObject);
	}
	
	void GameOver() {
		// game over, man, game over.
		Debug.Log ("Game over.");
	}
}