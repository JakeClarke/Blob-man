using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public GameObject model1;
	public GameObject model2;
	private GameObject currentModel;
	
	public float speed = 2;
	public float rollSpeed;
	public float rollTime = 1; // the amount of time it takes to roll
	public float rollBreak = 1; // the amount of time it takes between rolls
	public Vector3 jumpAmount;
	public float rightAngle = 270;
	public float leftAngle = 90;
	public GameObject camera;
	
	
	private bool onGround;
	private bool rolling;
	private float CameraDistanceY;
	private float _rollTime;
	private float _rollBreak;
	
	private static int BURGERMAN = 1;
	private static int SPHERE = 2;
	
	// Use this for initialization
	void Start () {
		CameraDistanceY = camera.transform.position.y - transform.position.y;
		_rollTime = rollTime;
		_rollBreak = rollBreak;
		
		currentModel = Instantiate(model1, transform.position, transform.rotation) as GameObject;
		currentModel.transform.parent = transform;
		
		// Player looks to the right when starting
		transform.eulerAngles = new Vector3(0, rightAngle, 0);
	}
	
	// Update is called once per frame
	void Update () {
		DetectGround();
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
			
			// Change rolling direction
			if (rollSpeed < 0)
				rollSpeed = -rollSpeed;
			
			
			transform.Translate(0, 0, - speed * Time.deltaTime);
			
		} 
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			
			if (transform.eulerAngles.y != leftAngle){
				transform.eulerAngles = new Vector3(0, leftAngle, 0);
			}
			
			// Change rolling direction
			if (rollSpeed > 0)
				rollSpeed = -rollSpeed;
			
			transform.Translate(0, 0, - speed * Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.UpArrow) && onGround == true)
		{
			//transform.Translate(0, jumpAmount * Time.deltaTime, 0);
			rigidbody.AddForce(jumpAmount, ForceMode.Impulse);
			onGround = false;
		}
		
		// -----------------------------------------------------
		//
		//		Rolling
		//
		// -----------------------------------------------------
		
		if (Input.GetKey(KeyCode.Space) && rolling == false && _rollTime > 0)
		{
			startRolling();
		}
		
		if (rolling == true)
		{
			// Keep rolling based on the _rollTime specified
			roll ();	
		}
		
		if (_rollTime <= 0)
		{
			_rollBreak -= Time.deltaTime;
			rolling = false;
			ChangeModel(BURGERMAN);
			
			if (_rollBreak <= 0)
			{
				_rollTime = rollTime;
				_rollBreak = rollBreak;							
			}
		}
		
		// -----------------------------------------------------
		//
		//		Camera follows the player
		//
		// -----------------------------------------------------
		camera.transform.position = new Vector3(transform.position.x, transform.position.y + CameraDistanceY, camera.transform.position.z);	
				
	}
	
	void FixedUpdate() {
		// Check to see if the player has fallen off the map
		// and respawn him
		if (transform.position.y < 0)
		{
			GameObject spawnPoint = GameObject.Find("SpawnPoint");
			transform.position = spawnPoint.transform.position;
		}
	}
	
	public void ChangeModel(int model_type)
	{
		if (model_type == SPHERE)
		{
			GameObject thisModel = Instantiate(model2, transform.position, transform.rotation) as GameObject;
			Destroy(currentModel);
			thisModel.transform.parent = transform;
			currentModel = thisModel;
		}
		else if (model_type == BURGERMAN)
		{
			GameObject thisModel = Instantiate(model1, transform.position, transform.rotation) as GameObject;
			Destroy(currentModel);
			thisModel.transform.parent = transform;
			currentModel = thisModel;
		}
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
	
	void OnCollisionExit() 
	{
		onGround = false;	
	}
	
	void startRolling()
	{
		rolling = true;
		ChangeModel(SPHERE);
		roll ();
	}
	
	void roll() {
		rigidbody.AddForce(new Vector3(rollSpeed, 0, 0), ForceMode.Impulse);	
		_rollTime -= Time.deltaTime;
	}
	
	void GameOver() {
		// game over, man, game over.
		Debug.Log ("Game over.");
	}
	
	void DetectGround() {
		Vector3 rayOrigin = this.transform.position + new Vector3(0f, 0.1f, 0f);
		Vector3 rayDir = new Vector3(0,-1,0);
		float rayLength = 1f;
		onGround = Physics.Raycast(rayOrigin, rayDir, rayLength);
		Debug.Log (onGround);
		Debug.DrawRay (rayOrigin, rayDir * rayLength, Color.red);
	}
}
