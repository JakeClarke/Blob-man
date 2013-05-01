using UnityEngine;
using System.Collections;

public class GUIScore : MonoBehaviour {
	
	private ScoreController scoreController;
	private SpawnController spawnController;
	
	void Start () {
		GameObject scoreEnt = GameObject.FindGameObjectWithTag("Score");
		scoreController = scoreEnt.GetComponent("ScoreController") as ScoreController;
		spawnController = scoreEnt.GetComponent("SpawnController") as SpawnController;
	}

	void OnGUI () {
		GUI.Box(new Rect(20,20, 140,40), "Score: " + scoreController.Score + "\n" + "Lives: " + spawnController.lives);
	}
}