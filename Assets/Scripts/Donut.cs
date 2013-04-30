using UnityEngine;

using System.Collections;

 

public class Donut : MonoBehaviour {

 
	static public int score = 0;
	
	void Update () {
		
		print (score);
	}
	
	
    void OnCollisionEnter(Collision col) {
		
		if (col.collider.tag == "Player") {
			score += 10;
			Destroy(gameObject);
		}
    }
	

}