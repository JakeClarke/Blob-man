using UnityEngine;

using System.Collections;

 

public class Donut : MonoBehaviour {
	
	private ScoreController scoreController;
	
	public float scoreGained = 20f;
	
	void Start () {
		GameObject scoreEnt = GameObject.FindGameObjectWithTag("Score");
		scoreController = scoreEnt.GetComponent("ScoreController") as ScoreController;
	}
	
    void OnTriggerEnter(Collider col) {
		
		if (col.tag == "Player") {
			scoreController.Score = scoreController.Score + scoreGained;
			Destroy(gameObject);
		}
    }
	

}