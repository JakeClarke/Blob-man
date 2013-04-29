using UnityEngine;
using System.Collections;

public class WallDestroy : MonoBehaviour {
	
	public int numberOfBricks = 10;
	public float explosionForce = 100f;
	public float explosionSize = 10f;
	public GameObject brickPrefab;
	public GameObject smokePrefab;
	public float breakThreshold = 20f;
	public Vector3 explosionOffset = new Vector3(-10, 10, 0);
	private Vector3 _posOffset = new Vector3(0f, 10f,0f);
	
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Player" && collision.impactForceSum.x > breakThreshold) {
			Break();
		}	
	}
	
	public void Break() {
		
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		for (int i = 0; i < this.numberOfBricks; i++) {
			GameObject b = (GameObject)Instantiate(this.brickPrefab, this.transform.position + this._posOffset + Random.insideUnitSphere, Random.rotation);
			Physics.IgnoreCollision(b.collider, player.collider);
			b.rigidbody.AddExplosionForce(this.explosionForce, this.transform.position + explosionOffset, explosionSize);
		}
		
		Instantiate(smokePrefab, this.transform.position, Quaternion.identity);
		
		Destroy(this.gameObject);
	}
}