using UnityEngine;
using System.Collections;

public class DeathCollide : MonoBehaviour {
	
	void OnCollisionEnter(Collision collision) {
		if(collision.collider.tag == "Player") {
			collision.collider.SendMessage("GameOver", "Don't fall!");
		}
		else
			Destroy(collision.collider.gameObject);
	}
}
