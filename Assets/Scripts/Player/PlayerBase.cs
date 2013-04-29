using UnityEngine;
using System.Collections;

public class PlayerBase : MonoBehaviour {
	
	/// <summary>
	/// The game over level.
	/// </summary>
	public string GameOverLevel = "GameOver";
	
	/// <summary>
	/// Default player initialisation code.
	/// </summary>
	public void Start() {
		CameraFollow camFollow = (CameraFollow)Camera.mainCamera.GetComponent("CameraFollow");
		camFollow.target = this.transform;	
	}
	
	/// <summary>
	/// Loads the game over level.
	/// </summary>
	public void GameOver() {
		Debug.Log ("Game over.");
		Application.LoadLevel(GameOverLevel);
	}
}
