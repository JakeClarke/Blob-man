using UnityEngine;

using System.Collections;

 

public class Donut : MonoBehaviour {
	
	private ScoreController scoreController;
	
	public float scoreGained = 20f;
	
	void Start () {
		GameObject scoreEnt = GameObject.FindGameObjectWithTag("Score");
		scoreController = scoreEnt.GetComponent("ScoreController") as ScoreController;
	}
	
    void OnCollisionEnter(Collision col) {
		
		if (col.collider.tag == "Player") {
			scoreController.Score = scoreController.Score + scoreGained;
			Destroy(gameObject);
		}
    }
	

}