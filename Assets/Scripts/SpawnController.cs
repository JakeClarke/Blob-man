using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
	
	/// <summary>
	/// The active spawn, exposed only for the editor. DO NOT CHANGE IN CODE.
	/// </summary>
	public GameObject activeSpawn;
	public int lives = 3;
	static public int deathPenalty = -10;
	
	private ScoreController _scoreController;

	// Use this for initialization
	void Start () {
		if (this.activeSpawn != null) {
			activeSpawn.SendMessage("SetActive", true);
		}
		
		GameObject scoreEnt = GameObject.FindGameObjectWithTag("Score");
		_scoreController = scoreEnt.GetComponent("ScoreController") as ScoreController;
	}
	
	/// <summary>
	/// Respawns the player.
	/// </summary>
	void RespawnPlayer(string reason) {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		if (lives-- <= 0)
		{	
			this._scoreController.GameOverReason = reason;
			Debug.Log ("Game over.");
			// Application.LoadLevel(GameOverLevel);
		}
		else
		{
			this._scoreController.Score += deathPenalty;
			if(activeSpawn) {
				player.transform.position = activeSpawn.transform.position;
			}
			else { 
				Application.LoadLevel(Application.loadedLevel);	
			}
		}
	}
	
	/// <summary>
	/// Sets the active spawn.
	/// </summary>
	/// <param name='newActiveSpawn'>
	/// New active spawn.
	/// </param>
	void SetActiveSpawn(GameObject newActiveSpawn) {
		if(activeSpawn != null)
			activeSpawn.SendMessage("SetActive", false);
		activeSpawn = newActiveSpawn;
		if(activeSpawn != null)
			activeSpawn.SendMessage("SetActive", true);
	}

}
