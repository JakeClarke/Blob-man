using UnityEngine;
using System.Collections;

public class GUIScore : MonoBehaviour {
	
	private ScoreController scoreController;
	
	void Start () {
		GameObject scoreEnt = GameObject.FindGameObjectWithTag("Score");
		scoreController = scoreEnt.GetComponent("ScoreController") as ScoreController;	
	}

	void OnGUI () {
		GUI.Box(new Rect(20,20, 140,30), "Score: " + scoreController.Score);
	}
}