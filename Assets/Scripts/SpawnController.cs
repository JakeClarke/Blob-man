using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
	
	/// <summary>
	/// The active spawn, exposed only for the editor. DO NOT CHANGE IN CODE.
	/// </summary>
	public GameObject activeSpawn;

	// Use this for initialization
	void Start () {
		if (this.activeSpawn != null) {
			activeSpawn.SendMessage("SetActive", true);
		}
	}
	
	/// <summary>
	/// Respawns the player.
	/// </summary>
	void RespawnPlayer() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if(activeSpawn) {
			player.transform.position = activeSpawn.transform.position;
		}
		else { 
			Application.LoadLevel(Application.loadedLevel);	
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
