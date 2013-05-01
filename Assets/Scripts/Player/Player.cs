using UnityEngine;
using System.Collections;

public class Player : PlayerBase {
	
	public GameObject PlayerRolling;
	
	public float speed = 2;
	public float jumpAmount = 10f;
	private const float _RIGHTANGLE = 270;
	private const float _LEFTANGLE = 90;
	
	public float enemyHeadBounce = 10f;
	
	
	private bool onGround;
	private bool rolling;
	private float CameraDistanceY;
	
	private bool _blockToRoll = true;
	
	// Use this for initialization
	new void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
		// rotate the player model
		if(Input.GetAxis("Horizontal") < 0) {
			transform.eulerAngles = new Vector3(0, _LEFTANGLE, 0);
		}
		else if(Input.GetAxis("Horizontal") > 0) {
			transform.eulerAngles = new Vector3(0, _RIGHTANGLE, 0);
		}
		
		if (Input.GetButton("Jump") && onGround == true)
		{
			//transform.Translate(0, jumpAmount * Time.deltaTime, 0);
			rigidbody.AddForce(new Vector3(0, jumpAmount, 0), ForceMode.Impulse);
			onGround = false;
		}
		
		// move the player.
		transform.Translate(0, 0, -Mathf.Abs((-speed * Time.deltaTime) * Input.GetAxis("Horizontal")));
		
		// thinking about making it so the player has to go through a world element to switch to ball mode.
		if(Input.GetButton("Fire1") && !this._blockToRoll) {
			this.ToRolling();
		}
		else if(!Input.GetButton("Fire1")) {
			_blockToRoll = false;
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
				this.rigidbody.AddForce(0f, this.enemyHeadBounce, 0f, ForceMode.Impulse);
				collision.gameObject.SendMessage("onHit");
			}
		}
		else if(collision.gameObject.tag == "Enemy") {
			GameOver("Burger people bad!");
		}
		
	}
	
	public void ToRolling() {
		this.PlayerRolling = (GameObject)Instantiate(this.PlayerRolling, this.transform.position, this.transform.rotation);
		this.PlayerRolling.rigidbody.velocity = this.rigidbody.velocity;
		Destroy(this.gameObject);
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
