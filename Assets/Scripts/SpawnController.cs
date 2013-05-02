using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
	
	/// <summary>
	/// The active spawn, exposed only for the editor. DO NOT CHANGE IN CODE.
	/// </summary>
	public GameObject activeSpawn;
	public int lives = 3;
	public int deathPenalty = -10;
	
	public string GameOverLevel = "GameOver";
	
	private ScoreController _scoreController;
	private int _checkPointScore = 0;
	private Vector3 _spawnLocation;
	private bool _movePlayerToSpawn = false;
	
	void Awake () {
		// prevent there from being more then one of these state managers in the level at once.
		if (GameObject.FindGameObjectsWithTag("Score").Length > 1) {
			Destroy (this.gameObject);
		}	
	}

	// Use this for initialization
	void Start () {
		if (this.activeSpawn != null) {
			activeSpawn.SendMessage("SetActive", true);
		}

		_scoreController = this.gameObject.GetComponent("ScoreController") as ScoreController;
	}
	
	/// <summary>
	/// Respawns the player.
	/// </summary>
	void RespawnPlayer(string reason) {
		_movePlayerToSpawn = false;
		
		if (lives-- <= 0)
		{	
			this._scoreController.GameOverReason = reason;
			Debug.Log ("Game over.");
			Application.LoadLevel(GameOverLevel);
		}
		else
		{
			this._scoreController.Score = this._checkPointScore + deathPenalty;
			if(activeSpawn) {
				_spawnLocation = activeSpawn.transform.position;
				_movePlayerToSpawn = true;
				Application.LoadLevel(Application.loadedLevel);
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
		this._checkPointScore = this._scoreController.Score;
		if(activeSpawn != null)
			activeSpawn.SendMessage("SetActive", true);
	}
	
	void OnLevelWasLoaded(int level) {
		if(this._movePlayerToSpawn) {
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			player.transform.position = _spawnLocation;
		}
    }
}
