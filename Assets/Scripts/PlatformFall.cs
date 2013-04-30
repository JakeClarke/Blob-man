using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour {
	
	public Vector3 fallSpeed = new Vector3(0f, 0.5f, 0f);
	public float holdTime = 3f;
	public float shakeForce = 0.5f;
	public float shakeFreq = 10f;
	private float _activeTime = 0f;
	private bool _isActivited = false;
	private Vector3 _startingPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!this._isActivited)
			return;
		
		if (this._activeTime > this.holdTime) {
			this.transform.position = this.transform.position - this.fallSpeed;
		}
		else {
			float shakeAmmount = Mathf.Sin(this._activeTime * shakeFreq) * shakeForce;
			Vector3 shakePos = this._startingPos;
			shakePos.x = shakePos.x + shakeAmmount;
			this.transform.position = shakePos;
		}
		
		this._activeTime += Time.deltaTime;
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Player") {
			this._startingPos = this.transform.position;
			this._isActivited = true;
		}
	}
}
