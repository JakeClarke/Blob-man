using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {
	
	public string levelToLoad = "LevelScene";
	
	void OnGUI () {
		GUI.Box(new Rect(0,0, 140,70), "Game Over!");
		if(GUI.Button(new Rect(10,40,100,30), "Restart")) {
			Application.LoadLevel(levelToLoad);
		}
	}
}
