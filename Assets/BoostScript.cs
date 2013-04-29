using UnityEngine;
using System.Collections;

public class BoostScript : MonoBehaviour {
	
	public float boostForce = 10f;

	void OnTriggerStay(Collider collider) {
		collider.attachedRigidbody.AddForce(this.transform.forward * boostForce);
	}
}
