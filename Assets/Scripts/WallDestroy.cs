using UnityEngine;
using System.Collections;

public class WallDestroy : MonoBehaviour {
	
	public int numberOfBricks = 10;
	public float explosionForceScaler = 1f;
	public float explosionSize = 10f;
	public GameObject brickPrefab;
	public GameObject smokePrefab;
	public float breakThreshold = 20f;
	public float explosionDirScaler = -10f;
	private Vector3 _posOffset = new Vector3(0f, 1f,0f);
	
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Player" && collision.impactForceSum.x > breakThreshold) {
			Debug.Log (collision.impactForceSum.magnitude);
			for (int i = 0; i < this.numberOfBricks; i++) {
				GameObject b = (GameObject)Instantiate(this.brickPrefab, this.transform.position + this._posOffset + Random.insideUnitSphere, Random.rotation);
				b.rigidbody.AddExplosionForce(collision.relativeVelocity.magnitude * explosionForceScaler, this.transform.position + (explosionDirScaler * collision.contacts[0].normal), explosionSize);
			}
			Instantiate(smokePrefab, this.transform.position, Quaternion.identity);
			
			Destroy(this.gameObject);
		}	
	}
}