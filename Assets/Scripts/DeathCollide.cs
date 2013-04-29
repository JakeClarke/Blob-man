using UnityEngine;
using System.Collections;

public class DeathCollide : MonoBehaviour {
	
	void OnCollisionEnter(Collision collision) {
		if(collision.collider.tag == "Player") {
			collider.collider.SendMessage("GameOver");
		}
		Destroy(collision.collider.gameObject);
	}
}
