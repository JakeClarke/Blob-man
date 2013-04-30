using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {
	
	public string levelToLoad = "LevelScene";
	
	private float score;
	
	void Start () {
		GameObject scoreEnt = GameObject.FindGameObjectWithTag("Score");
		ScoreController scoreController = scoreEnt.GetComponent("ScoreController") as ScoreController;
		this.levelToLoad = scoreController.CurrentLevel;
		this.score = scoreController.Score;
		Destroy(scoreEnt);		
	}
	
	void OnGUI () {
		GUI.Box(new Rect(0,0, 140,70), "Game Over! Score: " + this.score);
		if(GUI.Button(new Rect(10,40,100,30), "Restart")) {
			Application.LoadLevel(levelToLoad);
		}
	}
}
