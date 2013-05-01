using UnityEngine;

using System.Collections;

 

public class Donut : MonoBehaviour {
	
	
	public int scoreGained = 20;
	
	void Start () {
	}
	
    void OnTriggerEnter(Collider col) {
		
		if (col.tag == "Player") {
			col.SendMessage ("AddScore", scoreGained);
			Destroy(gameObject);
		}
    }
}