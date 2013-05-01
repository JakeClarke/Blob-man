using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {
	
	public string levelToLoad = "LevelScene";
	public Vector2 boxSize = new Vector2(200f,100f);
	public Vector2 buttonSize = new Vector2(70f, 35f);
	
	private string reason;
	private float score;
	
	void Start () {
		GameObject scoreEnt = GameObject.FindGameObjectWithTag("Score");
		if (scoreEnt != null) {
			ScoreController scoreController = scoreEnt.GetComponent("ScoreController") as ScoreController;
			this.levelToLoad = scoreController.CurrentLevel;
			this.score = scoreController.Score;
			this.reason = scoreController.GameOverReason;
			Destroy(scoreEnt);
		}		
	}
	
	void OnGUI () {
		GUI.BeginGroup(new Rect (Screen.width / 2 - (boxSize.x / 2), Screen.height / 2 - (boxSize.y / 2), boxSize.x, boxSize.y));
		GUI.Box(new Rect(0,0, boxSize.x, boxSize.y), "Game Over!\n"+ reason +"\nScore: " + this.score);
		if(GUI.Button(new Rect(boxSize.x / 2 - buttonSize.x /2,  60, buttonSize.x, buttonSize.y), "Restart")) {
			Application.LoadLevel(levelToLoad);
		}
		
		GUI.EndGroup();
	}
}
