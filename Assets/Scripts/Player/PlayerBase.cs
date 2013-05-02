using UnityEngine;
using System.Collections;

public abstract class PlayerBase : MonoBehaviour {

	private ScoreController _scoreController;
	
	/// <summary>
	/// Default player initialisation code.
	/// </summary>
	public void Start() {
		CameraFollow camFollow = Camera.mainCamera.GetComponent("CameraFollow") as CameraFollow;
		camFollow.target = this.transform;
		
		GameObject scoreEnt = GameObject.FindGameObjectWithTag("Score");
		_scoreController = scoreEnt.GetComponent("ScoreController") as ScoreController;
	}
	
	/// <summary>
	/// Loads the game over level.
	/// </summary>
	public void GameOver(string reason = "") {
		_scoreController.gameObject.SendMessage("RespawnPlayer", reason);
	}
	
	/// <summary>
	/// Adds the points.
	/// </summary>
	/// <param name='scoreToAdd'>
	/// Score to add.
	/// </param>
	public void AddScore(int scoreToAdd) {
		_scoreController.Score += scoreToAdd;
	}
}
